using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using BannerlordCheats.Extensions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), nameof(DefaultMobilePartyFoodConsumptionModel.CalculateDailyFoodConsumptionf))]
    public static class NoArmyFoodConsumptionPatch
    {
        [HarmonyPostfix]
        public static void CalculateDailyFoodConsumptionf(ref MobileParty party, ref bool includeDescription, ref ExplainedNumber __result)
        {
            if (party != null
                && party.Army != null
                && party.Army.Parties.Any(x => x?.IsMainParty ?? false)
                && BannerlordCheatsSettings.Instance.ArmyFoodConsumptionPercentage < 100)
            {
                __result.AddPercentage(BannerlordCheatsSettings.Instance.ArmyFoodConsumptionPercentage);
            }
        }
    }
}
