using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultCompanionHiringPriceCalculationModel), nameof(DefaultCompanionHiringPriceCalculationModel.GetCompanionHiringPrice))]
    public static class FreeCompanionHiring
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetCompanionHiringPrice(Hero companion, ref int result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.FreeCompanionHiring == true)
                {
                    result = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(FreeCompanionHiring));
            }
        }
    }
}
