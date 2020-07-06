using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), nameof(DefaultMobilePartyFoodConsumptionModel.CalculateDailyFoodConsumptionf))]
    public static class NoFoodConsumptionPatch
    {
        [HarmonyPostfix]
        public static void CalculateDailyFoodConsumptionf(MobileParty party, StatExplainer explainer, ref float __result)
        {
            if (party?.IsMainParty ?? false)
            {
                var factor = BannerlordCheatsSettings.Instance.FoodConsumptionPercentage / 100f;

                __result *= factor;

                if (explainer != null)
                {
                    foreach (var line in explainer.Lines)
                    {
                        line.Number *= factor;
                    }
                }
            }
        }
    }
}
