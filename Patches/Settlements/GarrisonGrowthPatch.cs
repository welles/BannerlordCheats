using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.GarrisonChange), MethodType.Getter)]
    public static class GarrisonGrowthPatch
    {
        [HarmonyPostfix]
        public static void GarrisonChange(ref Town __instance, ref int __result)
        {
            if (__instance.IsPlayerTown()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.DailyGarrisonBonus, out var dailyGarrisonBonus))
            {
                __result += dailyGarrisonBonus;
            }
        }
    }
}
