using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

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
                    && SettingsManager.DailyFoodBonus.IsChanged)
                {
                    __result += SettingsManager.DailyFoodBonus.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyFoodBonus));
            }
        }
    }
}
