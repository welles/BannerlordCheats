using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.MilitiaChange), MethodType.Getter)]
    public static class DailyMilitiaBonusTown
    {
        [HarmonyPostfix]
        public static void MilitiaChange(ref Town __instance, ref float __result)
        {
            if (__instance.IsPlayerTown()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.DailyMilitiaBonus, out var dailyMilitiaBonus))
            {
                __result += dailyMilitiaBonus;
            }
        }
    }
}
