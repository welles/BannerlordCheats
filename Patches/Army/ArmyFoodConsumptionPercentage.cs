using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using BannerlordCheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Army
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), nameof(DefaultMobilePartyFoodConsumptionModel.CalculateDailyFoodConsumptionf))]
    public static class ArmyFoodConsumptionPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDailyFoodConsumptionf(
            ref MobileParty party,
            ref ExplainedNumber baseConsumption,
            ref ExplainedNumber result)
        {
            try
            {
                if (party.IsPlayerArmy()
                    && BannerlordCheatsSettings.Instance?.ArmyFoodConsumptionPercentage < 100f)
                {
                    result.AddPercentage(BannerlordCheatsSettings.Instance.ArmyFoodConsumptionPercentage);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ArmyFoodConsumptionPercentage));
            }
        }
    }
}
