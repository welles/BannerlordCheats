using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.LoyaltyChange), MethodType.Getter)]
    public static class DailyLoyaltyBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void LoyaltyChange(ref Town __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerTown()
                    && SettingsManager.DailyLoyaltyBonus.IsChanged)
                {
                    __result += SettingsManager.DailyLoyaltyBonus.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyLoyaltyBonus));
            }
        }
    }
}
