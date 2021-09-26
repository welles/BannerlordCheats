using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Localization;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.CalculateLearningLimit))]
    public static class LearningLimitMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateLearningLimit(
            ref int attributeValue,
            ref int focusValue,
            ref TextObject attributeName,
            ref bool includeDescriptions,
            ref ExplainedNumber __result)
        {
            if (BannerlordCheatsSettings.Instance?.LearningLimitMultiplier > 1f)
            {
                __result.AddMultiplier(BannerlordCheatsSettings.Instance.LearningLimitMultiplier);
            }
        }
    }
}
