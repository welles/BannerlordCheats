using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), nameof(DefaultMobilePartyFoodConsumptionModel.CalculateDailyFoodConsumptionf))]
    public static class FoodConsumptionPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDailyFoodConsumptionf(
            ref MobileParty party,
            ref ExplainedNumber baseConsumption,
            ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.FoodConsumptionPercentage.IsChanged)
                {
                    __result.AddPercentage(SettingsManager.FoodConsumptionPercentage.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(FoodConsumptionPercentage));
            }
        }
    }
}
