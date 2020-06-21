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
            if ((party?.IsMainParty ?? false)
                && BannerlordCheatsSettings.Instance.NoFoodConsumption)
            {
                __result = 0.0f;

                if (explainer != null)
                {
                    explainer.Lines.Clear();
                }
            }
        }
    }

    [HarmonyPatch(typeof(MobileParty), nameof(MobileParty.GetNumDaysForFoodToLast))]
    public static class NoFoodConsumptionPatchText
    {
        [HarmonyPostfix]
        public static void GetNumDaysForFoodToLast(ref MobileParty __instance, ref int __result)
        {
            if (__instance?.IsMainParty ?? false
                && BannerlordCheatsSettings.Instance.NoFoodConsumption)
            {
                __result = 1;
            }
        }
    }
}
