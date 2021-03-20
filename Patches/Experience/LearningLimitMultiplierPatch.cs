using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Localization;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.CalculateLearningLimit))]
    public static class LearningLimitMultiplierPatch
    {
        [HarmonyPostfix]
        public static void CalculateLearningLimit(
            ref int attributeValue,
            ref int focusValue,
            ref TextObject attributeName,
            ref bool includeDescriptions,
            ref ExplainedNumber __result)
        {
            if (BannerlordCheatsSettings.Instance.LearningLimitMultiplier > 1.0f)
            {
                __result.AddMultiplier(BannerlordCheatsSettings.Instance.LearningLimitMultiplier);
            }
        }
    }
}
