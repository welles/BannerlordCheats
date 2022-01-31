using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultCompanionHiringPriceCalculationModel), nameof(DefaultCompanionHiringPriceCalculationModel.GetCompanionHiringPrice))]
    public static class FreeCompanionHiring
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetCompanionHiringPrice(Hero companion, ref int __result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.FreeCompanionHiring == true)
                {
                    __result = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(FreeCompanionHiring));
            }
        }
    }
}
