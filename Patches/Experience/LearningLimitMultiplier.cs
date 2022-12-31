using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
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
            try
            {
                if (SettingsManager.LearningLimitMultiplier.IsChanged)
                {
                    __result.AddMultiplier(SettingsManager.LearningLimitMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(LearningLimitMultiplier));
            }
        }
    }
}
