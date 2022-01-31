using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.FoodChange), MethodType.Getter)]
    public static class DailyFoodBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void FoodChange(ref Town __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerTown()
                    && BannerlordCheatsSettings.Instance?.DailyFoodBonus > 0)
                {
                    __result += BannerlordCheatsSettings.Instance.DailyFoodBonus;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyFoodBonus));
            }
        }
    }
}
