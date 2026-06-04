#!/bin/bash
# 快速恢复脚本: 把游戏 DLL 还原到原版
# 用法: ./rebuild/restore_original.sh

set -e

GAME_DIR="/mnt/c/Program Files (x86)/Steam/steamapps/common/Mao's Legacy/China_Data/Managed"
GAME_DLL="$GAME_DIR/Assembly-CSharp.dll"

# 找最近的备份
BACKUP=$(ls -dt rebuild/game_backup_*/Assembly-CSharp.dll.original 2>/dev/null | head -1)

if [ ! -f "$BACKUP" ]; then
    echo "❌ 找不到备份文件，尝试使用仓库内的永久备份..."
    BACKUP="rebuild/backup_repo/Assembly-CSharp.dll.original"
fi

if [ ! -f "$BACKUP" ]; then
    echo "❌ 所有备份都找不到，无法恢复"
    exit 1
fi

echo "🔄 正在从 $BACKUP 恢复..."
cp "$BACKUP" "$GAME_DLL"
echo "✅ 恢复完成！当前 DLL:"
ls -la "$GAME_DLL"