using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.FoodChange), MethodType.Getter)]
    public static class SettlementFoodStocksChangePatch
    {
        [HarmonyPostfix]
        public static void FoodChange(ref Town __instance, ref float __result)
        {
            if ((__instance?.Owner?.Owner?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.SettlementFoodUsagePercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.SettlementFoodUsagePercentage / 100f;

                var newValue = 0f;

                foreach (var line in __instance.FoodChangeExplanation.Lines)
                {
                    var value = line.Number;

                    if (value < 0)
                    {
                        value *= factor;
                    }

                    newValue += value;
                }

                __result = newValue;
            }
        }
    }

    [HarmonyPatch(typeof(Town), nameof(Town.FoodChangeExplanation), MethodType.Getter)]
    public static class SettlementFoodStocksExplanationPatch
    {
        [HarmonyPostfix]
        public static void FoodChange(ref Town __instance, ref StatExplainer __result)
        {
            if ((__instance?.Owner?.Owner?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.SettlementFoodUsagePercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.SettlementFoodUsagePercentage / 100f;

                foreach (var line in __result.Lines)
                {
                    if (line.Number < 0)
                    {
                        line.Number *= factor;
                    }
                }
            }
        }
    }
}
