using BannerlordCheats.Settings;
using HarmonyLib;
using BannerlordCheats.Extensions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Army
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), nameof(DefaultMobilePartyFoodConsumptionModel.CalculateDailyFoodConsumptionf))]
    public static class ArmyFoodConsumptionPercentage
    {
        [HarmonyPostfix]
        public static void CalculateDailyFoodConsumptionf(ref MobileParty party, ref bool includeDescription, ref ExplainedNumber __result)
        {
            if (party.IsPlayerArmy()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.ArmyFoodConsumptionPercentage, out var armyFoodConsumptionPercentage))
            {
                __result.AddPercentage(armyFoodConsumptionPercentage);
            }
        }
    }
}
