﻿using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.SecurityChange), MethodType.Getter)]
    public static class DailySecurityBonus
    {
        [HarmonyPostfix]
        public static void SecurityChange(ref Town __instance, ref float __result)
        {
            if (__instance.IsPlayerTown()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.DailySecurityBonus, out var dailySecurityBonus))
            {
                __result += dailySecurityBonus;
            }
        }
    }
}