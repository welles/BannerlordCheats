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
        public static void LoyaltyChange(ref Town instance, ref float result)
        {
            try
            {
                if (instance.IsPlayerTown()
                    && BannerlordCheatsSettings.Instance?.DailyLoyaltyBonus > 0)
                {
                    result += BannerlordCheatsSettings.Instance.DailyLoyaltyBonus;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyLoyaltyBonus));
            }
        }
    }
}
