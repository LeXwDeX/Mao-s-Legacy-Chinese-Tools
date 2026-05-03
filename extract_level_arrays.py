#!/usr/bin/env python3
"""Phase 5: Extract level file array references and generate structured inventory."""

import json
import re
from datetime import datetime, timezone
from pathlib import Path
from collections import defaultdict

BASE = Path(__file__).parent
STRUCTURE = BASE / "decompiled" / "STRUCTURE.json"
CLASSIFIED = BASE / "decompiled" / "STRINGS_CLASSIFIED.json"
OUTPUT = BASE / "decompiled" / "LEVEL_TEXT_ARRAYS.json"

MAX_REFS_PER_INDEX = 10  # cap for high-frequency indices


def load_json(path):
    with open(path, encoding="utf-8") as f:
        return json.load(f)


def build_array_classes(structure):
    """Extract classes that have string[] fields."""
    result = []
    for cls in structure["classes"]:
        if cls["string_array_fields"]:
            result.append({
                "class_name": cls["class_name"],
                "file": cls["file"],
                "base_class": cls["base_class"],
                "string_arrays": [{"name": name} for name in cls["string_array_fields"]],
            })
    return result


def build_translation_pairs(structure):
    """Find en/ru field pairs (both string and string[] types)."""
    # Known pair patterns: _en/_ru, english_text/russian_text, text_engs/text_russ
    pair_patterns = [
        (re.compile(r"^(.+)_en$"), re.compile(r"^(.+)_ru$"), "_en", "_ru"),
        (re.compile(r"^(.+)_engs?$"), re.compile(r"^(.+)_russ?$"), "_engs", "_russ"),
        (re.compile(r"^english_(.+)$"), re.compile(r"^russian_(.+)$"), "english_", "russian_"),
        (re.compile(r"^traits_en$"), re.compile(r"^traits_ru$"), "traits_en", "traits_ru"),
    ]

    results = []
    for cls in structure["classes"]:
        field_names = {f["name"] for f in cls["serialized_fields"]}
        # Also include string_array_fields
        field_names.update(cls["string_array_fields"])

        pairs = []
        matched = set()

        # Direct known pairs
        known = [
            ("english_text", "russian_text"),
            ("text_engs", "text_russ"),
            ("traits_en", "traits_ru"),
            ("job_english_text", "job_russian_text"),
        ]
        for en, ru in known:
            if en in field_names and ru in field_names:
                pairs.append({"en_field": en, "ru_field": ru})
                matched.add(en)
                matched.add(ru)

        # Pattern-based: _en/_ru suffix
        for name in sorted(field_names - matched):
            if name.endswith("_en"):
                stem = name[:-3]
                ru_name = stem + "_ru"
                if ru_name in field_names and ru_name not in matched:
                    pairs.append({"en_field": name, "ru_field": ru_name})
                    matched.add(name)
                    matched.add(ru_name)

        if pairs:
            # Determine field type for each pair
            field_type_map = {}
            for f in cls["serialized_fields"]:
                field_type_map[f["name"]] = f["type"]
            for arr_name in cls["string_array_fields"]:
                field_type_map[arr_name] = "string[]"

            for p in pairs:
                p["type"] = field_type_map.get(p["en_field"], "unknown")

            results.append({
                "class_name": cls["class_name"],
                "file": cls["file"],
                "pairs": pairs,
            })

    return results


def process_refs(classified, array_classes):
    """Process C_array_refs and D_translate_refs into index_usage and enrich array_classes."""
    # Combine all refs
    all_refs = classified.get("C_array_refs", []) + classified.get("D_translate_refs", [])

    # index_usage: array_name -> { by_index, numeric indices set, total_refs }
    usage = defaultdict(lambda: {"by_index": defaultdict(list), "numeric_indices": set(), "total_refs": 0})

    for ref in all_refs:
        arr = ref["array_name"]
        idx = ref["index"]
        entry = {"file": ref["file"], "method": ref["method"], "line": ref["line"]}

        usage[arr]["total_refs"] += 1

        if isinstance(idx, int):
            key = str(idx)
            usage[arr]["numeric_indices"].add(idx)
        else:
            key = "variable"

        usage[arr]["by_index"][key].append(entry)

    # Build final index_usage with capping
    index_usage = {}
    for arr_name, info in sorted(usage.items()):
        numeric = sorted(info["numeric_indices"])
        max_idx = max(numeric) if numeric else None

        by_index_capped = {}
        for key, refs in sorted(info["by_index"].items(), key=lambda x: x[0]):
            if len(refs) > MAX_REFS_PER_INDEX:
                by_index_capped[key] = refs[:MAX_REFS_PER_INDEX]
            else:
                by_index_capped[key] = refs

        index_usage[arr_name] = {
            "max_index": max_idx,
            "total_refs": info["total_refs"],
            "unique_numeric_indices": len(numeric),
            "referenced_indices": numeric,
            "by_index": by_index_capped,
        }

    # Enrich array_classes with ref data
    for cls in array_classes:
        for arr_info in cls["string_arrays"]:
            name = arr_info["name"]
            if name in usage:
                u = usage[name]
                numeric = sorted(u["numeric_indices"])
                arr_info["referenced_indices"] = numeric
                arr_info["max_index"] = max(numeric) if numeric else None
                arr_info["ref_count"] = u["total_refs"]
                arr_info["default_size"] = None
            else:
                arr_info["referenced_indices"] = []
                arr_info["max_index"] = None
                arr_info["ref_count"] = 0
                arr_info["default_size"] = None

        # Sort arrays by ref_count descending
        cls["string_arrays"].sort(key=lambda x: x["ref_count"], reverse=True)

    return index_usage


def main():
    structure = load_json(STRUCTURE)
    classified = load_json(CLASSIFIED)

    array_classes = build_array_classes(structure)
    translation_pairs = build_translation_pairs(structure)
    index_usage = process_refs(classified, array_classes)

    # Sort array_classes by total refs
    array_classes.sort(
        key=lambda c: sum(a["ref_count"] for a in c["string_arrays"]), reverse=True
    )

    # Compute summary
    total_refs = sum(v["total_refs"] for v in index_usage.values())
    estimated_strings = sum(
        (v["max_index"] + 1) for v in index_usage.values() if v["max_index"] is not None
    )
    total_pairs = sum(len(tp["pairs"]) for tp in translation_pairs)

    output = {
        "generated": datetime.now(timezone.utc).isoformat(),
        "summary": {
            "total_array_classes": len(array_classes),
            "total_string_arrays": sum(len(c["string_arrays"]) for c in array_classes),
            "estimated_translatable_strings": estimated_strings,
            "total_array_references": total_refs,
            "translation_pairs": total_pairs,
        },
        "array_classes": array_classes,
        "translation_pairs": translation_pairs,
        "index_usage": index_usage,
    }

    with open(OUTPUT, "w", encoding="utf-8") as f:
        json.dump(output, f, ensure_ascii=False, indent=2)

    # Print summary
    print(f"Output: {OUTPUT}")
    print(f"Summary: {json.dumps(output['summary'], indent=2)}")
    print()
    print("Array classes (by ref count):")
    for cls in array_classes:
        total = sum(a["ref_count"] for a in cls["string_arrays"])
        print(f"  {cls['class_name']} ({cls['file']}): {total} refs")
        for a in cls["string_arrays"]:
            print(f"    {a['name']}: max_index={a['max_index']}, refs={a['ref_count']}")
    print()
    print("Translation pairs:")
    for tp in translation_pairs:
        for p in tp["pairs"]:
            print(f"  {tp['class_name']}.{p['en_field']} / {p['ru_field']} ({p['type']})")
    print()
    print("Index usage (all arrays):")
    for name, info in sorted(index_usage.items(), key=lambda x: -x[1]["total_refs"]):
        print(f"  {name}: max_index={info['max_index']}, refs={info['total_refs']}, unique_indices={info['unique_numeric_indices']}")


if __name__ == "__main__":
    main()
