using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using BannerlordCheats.Extensions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Army
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), nameof(DefaultMobilePartyFoodConsumptionModel.CalculateDailyFoodConsumptionf))]
    public static class NoArmyFoodConsumptionPatch
    {
        [HarmonyPostfix]
        public static void CalculateDailyFoodConsumptionf(ref MobileParty party, ref bool includeDescription, ref ExplainedNumber __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.ArmyFoodConsumptionPercentage, out var armyFoodConsumptionPercentage)
                && (party?.Army?.Parties?.Any(x => x.IsPlayerParty()) ?? false))
            {
                __result.AddPercentage(armyFoodConsumptionPercentage);
            }
        }
    }
}
