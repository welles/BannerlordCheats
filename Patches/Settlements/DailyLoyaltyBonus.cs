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
                    && BannerlordCheatsSettings.Instance?.DailyLoyaltyBonus > 0)
                {
                    __result += BannerlordCheatsSettings.Instance.DailyLoyaltyBonus;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyLoyaltyBonus));
            }
        }
    }
}
