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
            ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerArmy()
                    && SettingsManager.ArmyFoodConsumptionPercentage.IsChanged)
                {
                    __result.AddPercentage(SettingsManager.ArmyFoodConsumptionPercentage.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ArmyFoodConsumptionPercentage));
            }
        }
    }
}
