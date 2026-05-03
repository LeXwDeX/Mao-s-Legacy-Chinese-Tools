#!/usr/bin/env python3
"""Extract class structure index from decompiled C# sources."""

import json
import os
import re
from datetime import datetime, timezone
from pathlib import Path

BASE_DIR = Path(__file__).parent / "decompiled"
OUT_FILE = BASE_DIR / "STRUCTURE.json"

# Patterns
# Class/struct/enum/interface declaration (handles generics, constraints, namespaces)
TYPE_DECL_RE = re.compile(
    r'^(?:\[.*?\]\s*\n?)*'  # attributes
    r'(?:public|internal|private|protected)?\s*'
    r'(?:static\s+|abstract\s+|sealed\s+|partial\s+)*'
    r'(class|struct|enum|interface)\s+'
    r'(\w+)'  # name
    r'(?:<[^>]+>)?'  # generic params
    r'(?:\s*:\s*([^\n{]+?))?'  # inheritance
    r'\s*(?:where\s+[^\n{]+?)?\s*$',
    re.MULTILINE
)

FIELD_RE = re.compile(
    r'^\t'  # single tab indent = class-level member
    r'(?:\[SerializeField\]\s*\n\t)?'  # optional SerializeField on prior line
    r'(public|private|protected|internal)\s+'
    r'(?!(?:static|const)\s)'  # exclude static/const
    r'(?:(?:static|const|readonly|volatile|new)\s+)*'
    r'(.+?)\s+'  # type
    r'(\w+)'  # name
    r'(?:\s*=\s*(.+?))?'  # default value
    r'\s*;',
    re.MULTILINE
)

METHOD_RE = re.compile(
    r'^\t(public|private|protected|internal)\s+'
    r'(?:(?:static|virtual|override|abstract|sealed|new|async|extern)\s+)*'
    r'([\w<>\[\],\s\?]+?)\s+'  # return type
    r'(\w+)\s*'  # name
    r'\(([^)]*)\)',  # params
    re.MULTILINE
)

LANGUAGE_CHECK_RE = re.compile(r'PlayerPrefs\.GetInt\s*\(\s*"language"\s*\)')


def parse_file(filepath: Path, relpath: str) -> list[dict]:
    text = filepath.read_text(encoding="utf-8-sig", errors="replace")
    results = []

    # Find all type declarations
    for m in TYPE_DECL_RE.finditer(text):
        kind = m.group(1)  # class/enum/interface/struct
        name = m.group(2)
        inheritance_str = (m.group(3) or "").strip()

        base_class = None
        interfaces = []
        if inheritance_str and kind in ("class", "struct"):
            parts = [p.strip() for p in inheritance_str.split(",")]
            for i, part in enumerate(parts):
                # Remove generic constraints (where ...)
                part = re.sub(r'\bwhere\b.*', '', part).strip()
                if not part:
                    continue
                # First part: if starts with I and has uppercase second char, likely interface
                # But MonoBehaviour, ScriptableObject etc are base classes
                if i == 0 and not (len(part) > 1 and part[0] == "I" and part[1].isupper() and "." not in part):
                    base_class = part
                elif i == 0 and part.startswith("I"):
                    interfaces.append(part)
                else:
                    interfaces.append(part)
        elif inheritance_str and kind == "interface":
            interfaces = [p.strip() for p in inheritance_str.split(",") if p.strip()]

        # Find the body of this type (from declaration to matching brace)
        decl_end = m.end()
        brace_pos = text.find("{", decl_end)
        if brace_pos == -1:
            body = ""
        else:
            depth = 0
            body_start = brace_pos
            pos = brace_pos
            while pos < len(text):
                if text[pos] == "{":
                    depth += 1
                elif text[pos] == "}":
                    depth -= 1
                    if depth == 0:
                        body = text[body_start:pos + 1]
                        break
                pos += 1
            else:
                body = text[body_start:]

        # Parse fields (only for class/struct)
        serialized_fields = []
        if kind in ("class", "struct"):
            # Check line by line for fields with [SerializeField] on preceding line
            lines = body.split("\n")
            serialize_next = False
            for line in lines:
                stripped = line.strip()
                if stripped == "[SerializeField]":
                    serialize_next = True
                    continue

                fm = re.match(
                    r'\t(public|private|protected|internal)\s+'
                    r'(?!(static|const)\b)'
                    r'(?:(?:readonly|volatile|new)\s+)*'
                    r'(.+?)\s+'
                    r'(\w+)'
                    r'(?:\s*=\s*(.+?))?'
                    r'\s*;',
                    line
                )
                if fm:
                    access = fm.group(1)
                    ftype = fm.group(3).strip()
                    fname = fm.group(4)
                    fdefault = (fm.group(5) or "").strip() or None

                    # Include if public OR has [SerializeField]
                    if access == "public" or serialize_next:
                        serialized_fields.append({
                            "name": fname,
                            "type": ftype,
                            "default_value": fdefault,
                        })
                    serialize_next = False
                else:
                    if not stripped.startswith("["):
                        serialize_next = False

        # Parse methods
        methods = []
        if kind in ("class", "struct", "interface"):
            for mm in METHOD_RE.finditer(body):
                methods.append({
                    "name": mm.group(3),
                    "access": mm.group(1),
                    "return_type": mm.group(2).strip(),
                    "params": mm.group(4).strip(),
                })

        has_language_branch = bool(LANGUAGE_CHECK_RE.search(body))

        string_array_fields = [
            f["name"] for f in serialized_fields if "string[]" in f["type"]
        ]

        results.append({
            "class_name": name,
            "file": relpath,
            "kind": kind,
            "base_class": base_class,
            "interfaces": interfaces,
            "serialized_fields": serialized_fields,
            "methods": methods,
            "has_language_branch": has_language_branch,
            "string_array_fields": string_array_fields,
        })

    return results


def main():
    all_classes = []
    for root, _dirs, files in os.walk(BASE_DIR):
        for fn in sorted(files):
            if not fn.endswith(".cs"):
                continue
            filepath = Path(root) / fn
            relpath = str(filepath.relative_to(BASE_DIR))
            try:
                entries = parse_file(filepath, relpath)
                all_classes.extend(entries)
            except Exception as e:
                print(f"ERROR parsing {relpath}: {e}")

    output = {
        "generated": datetime.now(timezone.utc).isoformat(),
        "total_classes": len(all_classes),
        "classes": all_classes,
    }

    OUT_FILE.write_text(json.dumps(output, indent=2, ensure_ascii=False), encoding="utf-8")
    print(f"Written {len(all_classes)} classes to {OUT_FILE}")

    # Stats
    mono = sum(1 for c in all_classes if c["base_class"] == "MonoBehaviour")
    lang = sum(1 for c in all_classes if c["has_language_branch"])
    sarr = sum(len(c["string_array_fields"]) for c in all_classes)
    print(f"  MonoBehaviour subclasses: {mono}")
    print(f"  Classes with language branch: {lang}")
    print(f"  Total string[] fields: {sarr}")


if __name__ == "__main__":
    main()
