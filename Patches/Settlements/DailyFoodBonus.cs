using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.FoodChange), MethodType.Getter)]
    public static class DailyFoodBonus
    {
        [HarmonyPostfix]
        public static void FoodChange(ref Town __instance, ref float __result)
        {
            if (__instance.IsPlayerTown()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.DailyFoodBonus, out var dailyFoodBonus))
            {
                __result += dailyFoodBonus;
            }
        }
    }
}
