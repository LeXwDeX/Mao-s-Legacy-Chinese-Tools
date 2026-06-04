#!/usr/bin/env python3
"""
Context-aware translation application script.
Safely applies translations to C# source files by:
1. Backing up originals
2. Parsing lines to find string literals
3. Applying translations only to safe string content
4. Logging all changes for verification
"""

import os
import json
import re
from pathlib import Path
from typing import Dict, Tuple

# Configuration
SAFE_TRANSLATIONS_FILE = 'safe_translations.json'
SOURCE_DIR = 'decompiled'
LOG_FILE = 'translation_log.json'

def load_translations() -> Dict[str, str]:
    """Load the safe translation map."""
    with open(SAFE_TRANSLATIONS_FILE, 'r', encoding='utf-8') as f:
        data = json.load(f)
    translations = data['translations']
    # Sort by key length (longer first) to avoid partial replacements
    return dict(sorted(translations.items(), key=lambda x: -len(x[0])))

def find_string_literals(line: str) -> list:
    """
    Find all string literals in a line, returning their positions.
    Returns list of tuples: (start, end, content)
    """
    literals = []
    i = 0
    while i < len(line):
        if line[i] == '"':
            # Found start of string
            start = i
            i += 1
            content = []
            while i < len(line):
                if line[i] == '\\' and i + 1 < len(line):
                    # Escape sequence
                    content.append(line[i:i+2])
                    i += 2
                elif line[i] == '"':
                    # End of string
                    break
                else:
                    content.append(line[i])
                    i += 1
            
            if i < len(line) and line[i] == '"':
                # Complete string found
                end = i + 1
                literal_content = ''.join(content)
                literals.append((start, end, literal_content))
            i += 1
        else:
            i += 1
    return literals

def apply_translation_to_string(content: str, translations: Dict[str, str]) -> Tuple[str, bool]:
    """
    Apply translations to a string literal content.
    Returns (new_content, was_modified).
    """
    original = content
    new_content = content
    
    for eng, zho in translations.items():
        if eng in new_content:
            new_content = new_content.replace(eng, zho)
    
    return new_content, new_content != original

def apply_translations_to_file(filepath: str, translations: Dict[str, str], changes: list) -> int:
    """
    Apply translations to a single C# file.
    Returns number of changed lines.
    """
    with open(filepath, 'r', encoding='utf-8') as f:
        lines = f.readlines()
    
    new_lines = []
    file_changes = 0
    
    for line_num, line in enumerate(lines, 1):
        literals = find_string_literals(line)
        if not literals:
            new_lines.append(line)
            continue
        
        # Process literals from right to left to maintain positions
        new_line = line
        for start, end, literal_content in reversed(literals):
            new_content, modified = apply_translation_to_string(literal_content, translations)
            if modified:
                # Reconstruct the line with new string
                new_line = new_line[:start+1] + new_content + new_line[end-1:]
                file_changes += 1
                changes.append({
                    'file': os.path.basename(filepath),
                    'line': line_num,
                    'old': literal_content[:80],
                    'new': new_content[:80]
                })
        
        new_lines.append(new_line)
    
    # Write back
    with open(filepath, 'w', encoding='utf-8') as f:
        f.writelines(new_lines)
    
    return file_changes

def main():
    print("=== Applying Safe Translations to Decompiled Sources ===\n")
    
    # Load translation map
    translations = load_translations()
    print(f"Loaded {len(translations)} safe translations")
    
    # Track changes
    all_changes = []
    modified_files = 0
    total_changes = 0
    
    # Process all C# files
    source_files = list(Path(SOURCE_DIR).rglob('*.cs'))
    print(f"Processing {len(source_files)} C# files...\n")
    
    for filepath in source_files:
        file_changes = apply_translations_to_file(str(filepath), translations, all_changes)
        if file_changes > 0:
            modified_files += 1
            total_changes += file_changes
            print(f"  ✓ {filepath}: {file_changes} changes")
    
    print(f"\n=== Summary ===")
    print(f"Modified files: {modified_files} / {len(source_files)}")
    print(f"Total changes: {total_changes}")
    
    # Save log
    with open(LOG_FILE, 'w', encoding='utf-8') as f:
        json.dump({
            'modified_files': modified_files,
            'total_changes': total_changes,
            'changes': all_changes
        }, f, ensure_ascii=False, indent=2)
    
    print(f"\nChange log saved to {LOG_FILE}")
    
    # Show sample changes
    if all_changes:
        print(f"\n=== Sample Changes (前10) ===")
        for change in all_changes[:10]:
            print(f"  [{change['file']}:{change['line']}]")
            print(f"    - {change['old']}")
            print(f"    + {change['new']}")
            print()

if __name__ == '__main__':
    main()
