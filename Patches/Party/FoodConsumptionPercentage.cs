using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), nameof(DefaultMobilePartyFoodConsumptionModel.CalculateDailyFoodConsumptionf))]
    public static class FoodConsumptionPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDailyFoodConsumptionf(ref MobileParty party, ref bool includeDescription, ref ExplainedNumber __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.FoodConsumptionPercentage < 100f)
            {
                __result.AddPercentage(BannerlordCheatsSettings.Instance.FoodConsumptionPercentage);
            }
        }
    }
}
