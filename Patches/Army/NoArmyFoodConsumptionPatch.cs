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
                && party.Army.Parties.Any(x => x?.IsMainParty ?? false)
                && BannerlordCheatsSettings.Instance.NoArmyFoodConsumption)
            {
                __result = 0.0f;

                if (explainer != null)
                {
                    explainer.Lines.Clear();
                }
            }
        }
    }
}
