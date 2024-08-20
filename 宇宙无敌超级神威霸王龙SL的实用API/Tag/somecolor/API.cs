﻿using Exiled.API.Features;
using UnityEngine;
using JBAPI.UnityScript;
using JBPI.Log;
using MEC;

namespace JBAPI.Tag
{
    public static class somecolor
    {
        private static readonly string[] 颜色 = new[]
        {
            "pink", "red", "brown", "silver",
            "light_green", "crimson", "cyan",
            "aqua","deep_pink","tomato",
            "yellow","magenta","blue_green",
            "orange","lime","green",
            "emerald","carmine","nickel",
              "mint","army_green","pumpkin"
        };

        public static void RTag(this Player 玩家, string 文本, bool 是否启用)
        {
            Timing.CallContinuously(2f, () =>
            {
                玩家.RankName = 文本;

                if (!是否启用)
                {
                    var 神威 = 玩家.GameObject.GetComponent<TagController>();
                    if (神威 != null)
                    {
                        Object.Destroy(神威);
                    }

                    玩家.RankColor = "red";

                    return;
                }

                var 霸王龙 = 玩家.GameObject.GetComponent<TagController>();

                LogAPI.日志($"JBAPI.somecolor调用 玩家 {玩家.Nickname} ({玩家.UserId})");
                LogAPI.自定义("111", System.ConsoleColor.Red);

                if (霸王龙 == null)
                {
                    霸王龙 = 玩家.GameObject.AddComponent<TagController>();
                    霸王龙.Colors = 颜色;
                    霸王龙.Interval = 0.5f;//孩子，时间越快服务器越容易崩，如果你改了，服务器爆炸概不负责
                }

            });
        }
    }
}
