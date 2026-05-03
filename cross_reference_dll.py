#!/usr/bin/env python3
"""Phase 4: Cross-reference DLL #US heap strings with decompiled code analysis."""

import json
import re
from datetime import datetime, timezone
from pathlib import Path
from collections import defaultdict

BASE = Path(__file__).parent
DECOMPILED = BASE / "decompiled"


def load_json(path):
    with open(path, "r", encoding="utf-8") as f:
        return json.load(f)


def normalize_strip(s):
    """Strip whitespace and trailing newlines."""
    return s.strip()


def normalize_nospace(s):
    """Remove all whitespace."""
    return re.sub(r"\s+", "", s)


def build_untranslatable_lookup(untrans):
    """Build text -> category lookup from UNTRANSLATABLE details."""
    unique = set(untrans["unique_strings"])
    # Build text -> first category from details
    cat_map = {}
    for d in untrans.get("details", []):
        t = d["text"]
        if t not in cat_map:
            cat_map[t] = d.get("category", "unknown")
    return unique, cat_map


def build_hardcoded_lookups(classified):
    """Build lookup tables for A_en_hardcoded strings."""
    entries = classified["A_en_hardcoded"]

    # exact (stripped) -> list of sources
    exact = defaultdict(list)
    # nospace -> list of sources
    nospace = defaultdict(list)
    # For substring matching: list of (stripped_text, sources)
    substr_candidates = []

    for e in entries:
        text = e["text"]
        src = {"file": e["file"], "method": e["method"], "line": e["line"]}

        stripped = normalize_strip(text)
        exact[stripped].append(src)

        ns = normalize_nospace(text)
        nospace[ns].append(src)

        if len(stripped) >= 10:
            substr_candidates.append((stripped, src))

    return exact, nospace, substr_candidates


def main():
    original = load_json(BASE / "dll_strings" / "original.json")
    classified = load_json(DECOMPILED / "STRINGS_CLASSIFIED.json")
    untrans = load_json(DECOMPILED / "UNTRANSLATABLE.json")

    bl_set, bl_cats = build_untranslatable_lookup(untrans)
    exact_map, nospace_map, substr_cands = build_hardcoded_lookups(classified)

    whitelist = []
    blacklist = []
    greylist = []
    wl_by_file = defaultdict(int)

    for hex_offset, entry in original.items():
        text = entry["text"]
        stripped = normalize_strip(text)
        ns = normalize_nospace(text)

        # 1. Blacklist check
        if stripped in bl_set:
            blacklist.append({
                "offset": hex_offset,
                "text": stripped,
                "reason": bl_cats.get(stripped, "untranslatable"),
                "category": bl_cats.get(stripped, "unknown"),
            })
            continue

        # 2. Whitelist: exact match
        sources = None
        confidence = "exact"
        if stripped in exact_map:
            sources = exact_map[stripped]
        elif ns in nospace_map:
            sources = nospace_map[ns]
            confidence = "nospace"
        else:
            # Substring: heap string contains a hardcoded string as substring
            # or hardcoded string contains heap string
            if len(stripped) >= 10:
                found = []
                for cand_text, cand_src in substr_cands:
                    if cand_text in stripped or stripped in cand_text:
                        found.append(cand_src)
                if found:
                    sources = found
                    confidence = "partial"

        if sources:
            # Deduplicate sources
            seen = set()
            unique_sources = []
            for s in sources:
                key = (s["file"], s["method"], s["line"])
                if key not in seen:
                    seen.add(key)
                    unique_sources.append(s)

            wl_entry = {
                "offset": hex_offset,
                "offset_dec": entry["offset"],
                "text": stripped,
                "available_chars": entry["available_chars"],
                "max_zh_chars": entry["available_chars"],
                "confidence": confidence,
                "sources": unique_sources,
            }
            whitelist.append(wl_entry)
            for s in unique_sources:
                wl_by_file[s["file"]] += 1
        else:
            greylist.append({
                "offset": hex_offset,
                "text": stripped,
                "available_chars": entry["available_chars"],
                "note": "未在反编译代码中找到精确匹配",
            })

    # Sort whitelist by offset
    whitelist.sort(key=lambda x: x["offset_dec"])
    blacklist.sort(key=lambda x: x["offset"])
    greylist.sort(key=lambda x: x["offset"])

    result = {
        "generated": datetime.now(timezone.utc).isoformat(),
        "summary": {
            "total_heap_strings": len(original),
            "whitelist": len(whitelist),
            "blacklist": len(blacklist),
            "greylist": len(greylist),
            "whitelist_exact": sum(1 for w in whitelist if w["confidence"] == "exact"),
            "whitelist_nospace": sum(1 for w in whitelist if w["confidence"] == "nospace"),
            "whitelist_partial": sum(1 for w in whitelist if w["confidence"] == "partial"),
            "whitelist_by_file": dict(sorted(wl_by_file.items(), key=lambda x: -x[1])),
        },
        "whitelist": whitelist,
        "blacklist": blacklist,
        "greylist": greylist,
    }

    # Validate
    total = len(whitelist) + len(blacklist) + len(greylist)
    assert total == len(original), f"Sum mismatch: {total} != {len(original)}"

    out_path = DECOMPILED / "DLL_PATCH_WHITELIST.json"
    with open(out_path, "w", encoding="utf-8") as f:
        json.dump(result, f, ensure_ascii=False, indent=2)

    print(f"=== Phase 4: DLL #US Heap Cross-Reference ===")
    print(f"Total heap strings: {len(original)}")
    print(f"Whitelist: {len(whitelist)} (exact={result['summary']['whitelist_exact']}, nospace={result['summary']['whitelist_nospace']}, partial={result['summary']['whitelist_partial']})")
    print(f"Blacklist: {len(blacklist)}")
    print(f"Greylist:  {len(greylist)}")
    print(f"Sum check: {total} == {len(original)} ✓")
    print(f"\nTop files by whitelist count:")
    for f, c in sorted(wl_by_file.items(), key=lambda x: -x[1])[:15]:
        print(f"  {f}: {c}")
    print(f"\nOutput: {out_path}")


if __name__ == "__main__":
    main()
