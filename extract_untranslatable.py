#!/usr/bin/env python3
"""Extract untranslatable strings from decompiled C# Unity source files."""

import json
import os
import re
from datetime import datetime, timezone

DECOMPILED_DIR = os.path.join(os.path.dirname(os.path.abspath(__file__)), "decompiled")
OUTPUT = os.path.join(DECOMPILED_DIR, "UNTRANSLATABLE.json")

# Pattern: (category, regex, context_label)
# Each regex must have group(1) = the string content
PATTERNS = [
    # 1. scene_names
    ("scene_names", r'SceneManager\.LoadScene(?:Async)?\s*\(\s*"([^"]+)"', "SceneManager.LoadScene"),
    ("scene_names", r'GetActiveScene\s*\(\s*\)\s*\.name\s*==\s*"([^"]+)"', "GetActiveScene().name"),
    ("scene_names", r'SceneManager\.GetSceneByName\s*\(\s*"([^"]+)"', "SceneManager.GetSceneByName"),

    # 2. input_axes
    ("input_axes", r'Input\.GetAxis(?:Raw)?\s*\(\s*"([^"]+)"', "Input.GetAxis"),
    ("input_axes", r'Input\.GetButton(?:Down|Up)?\s*\(\s*"([^"]+)"', "Input.GetButton"),
    ("input_axes", r'Input\.GetKey(?:Down|Up)?\s*\(\s*"([^"]+)"', "Input.GetKey"),

    # 3. gameobject_finds
    ("gameobject_finds", r'GameObject\.Find\s*\(\s*"([^"]+)"', "GameObject.Find"),
    ("gameobject_finds", r'GameObject\.FindWithTag\s*\(\s*"([^"]+)"', "GameObject.FindWithTag"),
    ("gameobject_finds", r'GameObject\.FindGameObjectWithTag\s*\(\s*"([^"]+)"', "GameObject.FindGameObjectWithTag"),
    ("gameobject_finds", r'[Tt]ransform\.Find\s*\(\s*"([^"]+)"', "transform.Find"),
    ("gameobject_finds", r'\.Find\s*\(\s*"([^"]+)"', "Find"),  # broader catch

    # 4. prefs_keys - match PlayerPrefs.Get*/Set*/Has* with string literal key
    ("prefs_keys", r'PlayerPrefs\.(?:Get|Set|Has|Delete)(?:Int|Float|String|Key)?\s*\(\s*"([^"]+)"', "PlayerPrefs"),

    # 5. material_props
    ("material_props", r'[Mm]aterial\.(?:Set|Get)(?:Float|Int|Color|Vector|Texture|Matrix|Tag)?\s*\(\s*"([^"]+)"', "material.Set/Get"),
    ("material_props", r'\.(?:Set|Get)(?:Float|Int|Color|Vector|Texture)?\s*\(\s*"(_[^"]+)"', "shader_property"),  # _ prefixed shader props

    # 6. animator_params
    ("animator_params", r'[Aa]nimator\.(?:Set|Get|Reset)(?:Bool|Float|Integer|Trigger|Int)?\s*\(\s*"([^"]+)"', "Animator.Set/Get"),
    ("animator_params", r'Animator>\s*\(\s*\)\s*\.(?:Set|Get)(?:Bool|Float|Integer|Trigger|Int)?\s*\(\s*"([^"]+)"', "GetComponent<Animator>"),
    ("animator_params", r'\.(?:Set|Get|Reset)(?:Bool|Float|Integer|Trigger)\s*\(\s*"([^"]+)"', "animator_param"),

    # 7. tags_layers
    ("tags_layers", r'CompareTag\s*\(\s*"([^"]+)"', "CompareTag"),
    ("tags_layers", r'\.tag\s*==\s*"([^"]+)"', "tag =="),
    ("tags_layers", r'\.tag\s*!=\s*"([^"]+)"', "tag !="),
    ("tags_layers", r'LayerMask\.NameToLayer\s*\(\s*"([^"]+)"', "LayerMask.NameToLayer"),
    ("tags_layers", r'SortingLayer\.NameToID\s*\(\s*"([^"]+)"', "SortingLayer.NameToID"),
]

def extract():
    details = []
    seen = set()  # (text, category, file, line) dedup

    for root, _, files in os.walk(DECOMPILED_DIR):
        for fname in files:
            if not fname.endswith(".cs"):
                continue
            fpath = os.path.join(root, fname)
            rel = os.path.relpath(fpath, DECOMPILED_DIR)
            try:
                with open(fpath, "r", encoding="utf-8", errors="replace") as f:
                    lines = f.readlines()
            except Exception:
                continue

            for i, line in enumerate(lines, 1):
                for category, pattern, context in PATTERNS:
                    for m in re.finditer(pattern, line):
                        text = m.group(1)
                        if not text:
                            continue
                        key = (text, category, rel, i)
                        if key in seen:
                            continue
                        seen.add(key)
                        details.append({
                            "text": text,
                            "category": category,
                            "file": rel,
                            "line": i,
                            "context": context,
                        })

    # Deduplicate: for gameobject_finds, the broad ".Find" pattern may duplicate specific ones
    # Remove broad "Find" entries if a more specific one exists for same text+file+line
    specific_keys = set()
    for d in details:
        if d["context"] != "Find":
            specific_keys.add((d["text"], d["file"], d["line"]))

    details = [d for d in details if d["context"] != "Find" or (d["text"], d["file"], d["line"]) not in specific_keys]

    # Build summary
    summary = {}
    for cat in ["scene_names", "input_axes", "gameobject_finds", "prefs_keys", "material_props", "animator_params", "tags_layers"]:
        summary[cat] = len([d for d in details if d["category"] == cat])

    unique = sorted(set(d["text"] for d in details))

    result = {
        "generated": datetime.now(timezone.utc).isoformat(),
        "summary": summary,
        "unique_strings": unique,
        "details": details,
    }

    with open(OUTPUT, "w", encoding="utf-8") as f:
        json.dump(result, f, indent=2, ensure_ascii=False)

    print(f"Output: {OUTPUT}")
    print(f"Total entries: {len(details)}")
    print(f"Unique strings: {len(unique)}")
    print(f"Summary: {json.dumps(summary, indent=2)}")
    print(f"\nUnique strings list:")
    for s in unique:
        print(f"  - {s}")

if __name__ == "__main__":
    extract()
