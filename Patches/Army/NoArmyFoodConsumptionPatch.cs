using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), nameof(DefaultMobilePartyFoodConsumptionModel.CalculateDailyFoodConsumptionf))]
    public static class NoArmyFoodConsumptionPatch
    {
        [HarmonyPostfix]
        public static void CalculateDailyFoodConsumptionf(MobileParty party, StatExplainer explainer, ref float __result)
        {
            if (party != null
                && party.Army != null
                && party.Army.Parties.Any(x => x?.IsMainParty ?? false))
            {
                var factor = BannerlordCheatsSettings.Instance.ArmyFoodConsumptionPercentage / 100f;

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
