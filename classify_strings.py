#!/usr/bin/env python3
"""
Phase 2: Extract and classify all string literals from decompiled C# sources.
Outputs STRINGS_CLASSIFIED.json with categories A-F.
"""

import os
import re
import json
import glob
from datetime import datetime, timezone

DECOMPILED_DIR = os.path.join(os.path.dirname(os.path.abspath(__file__)), "decompiled")
OUTPUT_PATH = os.path.join(DECOMPILED_DIR, "STRINGS_CLASSIFIED.json")

# ── Patterns ──

# Language condition patterns
RE_LANG_DIRECT_EQ0 = re.compile(r'PlayerPrefs\.GetInt\("language"\)\s*==\s*0')
RE_LANG_DIRECT_NEQ0 = re.compile(r'PlayerPrefs\.GetInt\("language"\)\s*!=\s*0')
RE_FLAG_ASSIGN = re.compile(
    r'bool\s+(\w+)\s*=\s*PlayerPrefs\.GetInt\("language"\)\s*(==|!=)\s*0'
)

# Array reference patterns (C and D class)
RE_ARRAY_REF = re.compile(
    r'(new_texts|other_text|new_modify_texts|new_modify_desc|country_texts|'
    r'new_focuses_texts|new_focuses_desc|new_events_text|new_events_desc|'
    r'button_texts|leader_texts|leader_desc|'
    r'english_text|russian_text|job_english_text|job_russian_text)\s*\[\s*([^\]]+?)\s*\]'
)

# D-class specific
D_ARRAYS = {'english_text', 'russian_text', 'job_english_text', 'job_russian_text'}

# Field default patterns (F class)
RE_FIELD_DEFAULT = re.compile(
    r'^\s*public\s+(string(?:\[\])?)\s+(\w+)\s*=\s*"([^"]*)"'
)

# String literal
RE_STRING_LITERAL = re.compile(r'"([^"\\]*(?:\\.[^"\\]*)*)"')

# Interpolated string
RE_INTERPOLATED = re.compile(r'\$"([^"\\]*(?:\\.[^"\\]*)*)"')

# Format placeholder
RE_FORMAT_PLACEHOLDER = re.compile(r'\{(\d+)\}')

# Assignment targets for UI text
RE_ASSIGNMENT_TARGET = re.compile(
    r'(\w+(?:\.\w+)*(?:\[\w+\])?)\s*=\s*(?:\$?")'
)

# .text assignment
RE_TEXT_PROP = re.compile(r'(\w+)\.text\s*=')

# Display variable names
DISPLAY_VARS = {
    'this_opis', 'uslovie_text', 'name_en', 'desc_en', 'fake_text',
    'text', 'text2', 'text3', 'opis', 'name_text', 'button_text',
}

# Russian character detection
RE_CYRILLIC = re.compile(r'[\u0400-\u04FF]')

# Class declaration
RE_CLASS_DECL = re.compile(r'^\s*(?:public|private|internal|protected)?\s*(?:static\s+)?class\s+(\w+)')

# Method declaration
RE_METHOD_DECL = re.compile(
    r'^\s*(?:public|private|protected|internal|static|virtual|override|abstract|sealed|\s)*'
    r'(?:\w+(?:<[^>]+>)?(?:\[\])?)\s+(\w+)\s*\('
)


def detect_language_block(lines):
    """
    Scan lines and return a list of (start, end, language) tuples for
    language-conditional blocks. language is 'en' or 'ru'.
    """
    blocks = []
    i = 0
    n = len(lines)

    # Track flag variables: flag_name -> 'eq0' or 'neq0'
    # eq0 means flag=true when language==0 (English)
    # neq0 means flag=true when language!=0 (Russian)
    flag_vars = {}

    while i < n:
        line = lines[i]

        # Check for flag assignment
        m = RE_FLAG_ASSIGN.search(line)
        if m:
            var_name = m.group(1)
            op = m.group(2)
            flag_vars[var_name] = op  # '==' or '!='

        # Direct condition: if (PlayerPrefs.GetInt("language") == 0)
        if RE_LANG_DIRECT_EQ0.search(line):
            # Find the if block and else block
            if_block = find_block(lines, i)
            if if_block:
                blocks.append((if_block[0], if_block[1], 'en'))
                # Look for else
                else_block = find_else_block(lines, if_block[1])
                if else_block:
                    blocks.append((else_block[0], else_block[1], 'ru'))
        elif RE_LANG_DIRECT_NEQ0.search(line):
            if_block = find_block(lines, i)
            if if_block:
                blocks.append((if_block[0], if_block[1], 'ru'))
                else_block = find_else_block(lines, if_block[1])
                if else_block:
                    blocks.append((else_block[0], else_block[1], 'en'))
        else:
            # Check for flag-based condition: if (flag) or if (!flag)
            for var_name, op in flag_vars.items():
                # if (flag)
                pat_true = re.compile(r'\bif\s*\(\s*' + re.escape(var_name) + r'\s*\)')
                pat_false = re.compile(r'\bif\s*\(\s*!' + re.escape(var_name) + r'\s*\)')

                if pat_true.search(line):
                    # flag is true
                    if op == '==':  # flag = lang==0, so flag true = English
                        true_lang, false_lang = 'en', 'ru'
                    else:  # flag = lang!=0, so flag true = Russian
                        true_lang, false_lang = 'ru', 'en'
                    if_block = find_block(lines, i)
                    if if_block:
                        blocks.append((if_block[0], if_block[1], true_lang))
                        else_block = find_else_block(lines, if_block[1])
                        if else_block:
                            blocks.append((else_block[0], else_block[1], false_lang))
                    break
                elif pat_false.search(line):
                    if op == '==':
                        true_lang, false_lang = 'ru', 'en'
                    else:
                        true_lang, false_lang = 'en', 'ru'
                    if_block = find_block(lines, i)
                    if if_block:
                        blocks.append((if_block[0], if_block[1], true_lang))
                        else_block = find_else_block(lines, if_block[1])
                        if else_block:
                            blocks.append((else_block[0], else_block[1], false_lang))
                    break

        i += 1

    return blocks


def find_block(lines, start_line):
    """Find the brace-delimited block starting from the if line. Returns (content_start, block_end)."""
    n = len(lines)
    i = start_line
    # Find opening brace
    while i < n:
        if '{' in lines[i]:
            break
        i += 1
        if i - start_line > 3:  # Single-line if without braces
            # Treat just the next line as the block
            if start_line + 1 < n:
                return (start_line, start_line + 2)
            return None
    if i >= n:
        return None

    # Count braces
    depth = 0
    block_start = start_line
    for j in range(i, n):
        line = lines[j]
        # Simple brace counting (ignoring strings/comments for speed)
        for ch in line:
            if ch == '{':
                depth += 1
            elif ch == '}':
                depth -= 1
                if depth == 0:
                    return (block_start, j + 1)
    return (block_start, n)


def find_else_block(lines, after_line):
    """Find else block immediately after a closing brace."""
    n = len(lines)
    # The closing brace line may have 'else' on it or the next line
    for check in range(max(0, after_line - 1), min(n, after_line + 2)):
        if check >= n:
            break
        line = lines[check].strip()
        if 'else' in line:
            return find_block(lines, check)
    return None


def get_method_at_line(lines, line_idx):
    """Walk backwards to find enclosing method name."""
    for i in range(line_idx, -1, -1):
        m = RE_METHOD_DECL.match(lines[i])
        if m:
            return m.group(1)
    return "unknown"


def get_class_at_line(lines, line_idx):
    """Walk backwards to find enclosing class name."""
    for i in range(line_idx, -1, -1):
        m = RE_CLASS_DECL.match(lines[i])
        if m:
            return m.group(1)
    return "unknown"


def is_interesting_string(s):
    """Filter out trivial strings: empty, single char, pure paths, pure numbers, tags."""
    if not s or len(s) <= 1:
        return False
    if s.startswith("<color") or s.startswith("</color"):
        return False
    if re.match(r'^[\d.]+$', s):
        return False
    if s in ('True', 'False', 'true', 'false', '\\n', '|', '\n', ' ', ', ', '.', '/', '?'):
        return False
    return True


# Strings that are API keys/parameters, not UI text
RE_PREFS_KEY = re.compile(r'PlayerPrefs\.\w+\(\s*"[^"]*"')
RE_FIND_CALL = re.compile(r'(?:Find|GetComponent|AddComponent|LoadScene|GetAxis|GetButton|GetTag)\s*[<(]\s*"')
RE_PATH_STRING = re.compile(r'^[\w/\\._-]+$')  # Pure path-like strings


def is_likely_ui_text(s, line):
    """Additional filter for A/B: is this likely user-visible text?"""
    # Skip PlayerPrefs keys
    if RE_PREFS_KEY.search(line):
        # Check if this particular string is the prefs key argument
        for m in re.finditer(r'PlayerPrefs\.\w+\("([^"]*)"', line):
            if m.group(1) == s:
                return False
    # Skip Find/GetComponent/etc arguments
    if RE_FIND_CALL.search(line):
        for m in re.finditer(r'(?:Find|GetComponent|AddComponent|LoadScene|GetAxis|GetButton|GetTag)\s*[<(]\s*"([^"]*)"', line):
            if m.group(1) == s:
                return False
    # Skip debug logs
    if 'Debug.Log' in line:
        return False
    # Skip pure paths/identifiers
    if RE_PATH_STRING.match(s) and '/' in s:
        return False
    return True


def extract_assignment_target(line):
    """Extract what the string is being assigned to."""
    m = RE_TEXT_PROP.search(line)
    if m:
        return m.group(1) + ".text"
    m = RE_ASSIGNMENT_TARGET.search(line)
    if m:
        return m.group(1)
    return None


def line_in_block(line_idx, blocks, lang):
    """Check if a line falls within any block of the given language."""
    for start, end, blang in blocks:
        if blang == lang and start <= line_idx < end:
            return True
    return False


def get_block_language(line_idx, blocks):
    """Return language of block containing this line, or None."""
    for start, end, lang in blocks:
        if start <= line_idx < end:
            return lang
    return None


def has_format_or_interpolation(s, line):
    """Check if string has format placeholders or if line uses interpolation with variables."""
    if RE_FORMAT_PLACEHOLDER.search(s):
        return True
    if line.strip().startswith('$"') or '= $"' in line or '+ $"' in line or '($"' in line:
        return True
    return False


def process_file(filepath, results):
    rel_path = os.path.relpath(filepath, DECOMPILED_DIR)

    with open(filepath, 'r', encoding='utf-8', errors='replace') as f:
        lines = f.readlines()

    # Strip newlines for processing
    lines = [l.rstrip('\n') for l in lines]

    # Detect language blocks
    lang_blocks = detect_language_block(lines)

    for i, line in enumerate(lines):
        # ── F class: field defaults ──
        m = RE_FIELD_DEFAULT.match(line)
        if m:
            ftype, fname, fval = m.group(1), m.group(2), m.group(3)
            if is_interesting_string(fval):
                class_name = get_class_at_line(lines, i)
                results['F_field_defaults'].append({
                    'text': fval,
                    'file': rel_path,
                    'class_name': class_name,
                    'field_name': fname,
                    'field_type': ftype,
                })

        # ── C/D class: array references ──
        for m in RE_ARRAY_REF.finditer(line):
            arr_name = m.group(1)
            idx_str = m.group(2).strip()
            try:
                idx = int(idx_str)
            except ValueError:
                idx = idx_str  # variable index like 'i', '(int)job'
            method = get_method_at_line(lines, i)
            # Simplify context
            context = line.strip()
            if len(context) > 150:
                context = context[:150] + "..."

            entry = {
                'array_name': arr_name,
                'index': idx,
                'file': rel_path,
                'method': method,
                'line': i + 1,
                'context': context,
            }
            if arr_name in D_ARRAYS:
                results['D_translate_refs'].append(entry)
            else:
                results['C_array_refs'].append(entry)

        # ── A/B/E class: string literals in code ──
        # Skip field declarations (already handled as F) and using/namespace lines
        stripped = line.strip()
        if stripped.startswith('using ') or stripped.startswith('namespace '):
            continue
        if RE_FIELD_DEFAULT.match(line):
            continue

        # Find all string literals on this line
        for m in RE_STRING_LITERAL.finditer(line):
            s = m.group(1)
            if not is_interesting_string(s):
                continue

            method = get_method_at_line(lines, i)
            lang = get_block_language(i, lang_blocks)
            target = extract_assignment_target(line)
            has_cyrillic = bool(RE_CYRILLIC.search(s))
            is_format = has_format_or_interpolation(s, line)

            # ── E class: format/interpolation strings ──
            if is_format:
                if lang:
                    e_lang = lang
                elif has_cyrillic:
                    e_lang = 'ru'
                else:
                    e_lang = 'unknown'
                results['E_format_strings'].append({
                    'text': s,
                    'file': rel_path,
                    'method': method,
                    'line': i + 1,
                    'language': e_lang,
                })
                # Also classify as A/B if in a language block
                # (fall through)

            # ── A/B class: hardcoded UI text ──
            if lang == 'en' and not has_cyrillic and is_likely_ui_text(s, line):
                results['A_en_hardcoded'].append({
                    'text': s,
                    'file': rel_path,
                    'method': method,
                    'line': i + 1,
                    'assignment_target': target,
                })
            elif lang == 'ru' and is_likely_ui_text(s, line):
                results['B_ru_hardcoded'].append({
                    'text': s,
                    'file': rel_path,
                    'method': method,
                    'line': i + 1,
                    'assignment_target': target,
                })
            elif lang is None and has_cyrillic and is_likely_ui_text(s, line):
                # Cyrillic outside explicit block → likely Russian
                results['B_ru_hardcoded'].append({
                    'text': s,
                    'file': rel_path,
                    'method': method,
                    'line': i + 1,
                    'assignment_target': target,
                })


def main():
    results = {
        'A_en_hardcoded': [],
        'B_ru_hardcoded': [],
        'C_array_refs': [],
        'D_translate_refs': [],
        'E_format_strings': [],
        'F_field_defaults': [],
    }

    cs_files = glob.glob(os.path.join(DECOMPILED_DIR, '**', '*.cs'), recursive=True)
    cs_files.sort()
    print(f"Processing {len(cs_files)} .cs files...")

    for fp in cs_files:
        process_file(fp, results)

    summary = {
        'A_en_hardcoded': len(results['A_en_hardcoded']),
        'B_ru_hardcoded': len(results['B_ru_hardcoded']),
        'C_array_refs': len(results['C_array_refs']),
        'D_translate_refs': len(results['D_translate_refs']),
        'E_format_strings': len(results['E_format_strings']),
        'F_field_defaults': len(results['F_field_defaults']),
    }

    output = {
        'generated': datetime.now(timezone.utc).isoformat(),
        'summary': summary,
        **results,
    }

    with open(OUTPUT_PATH, 'w', encoding='utf-8') as f:
        json.dump(output, f, ensure_ascii=False, indent=2)

    print(f"\nOutput: {OUTPUT_PATH}")
    print(f"Summary:")
    for k, v in summary.items():
        print(f"  {k}: {v}")


if __name__ == '__main__':
    main()
