using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.CalculateLearningRate), new[] { typeof(Hero), typeof(SkillObject) })]
    public static class LearningRateMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateLearningRate(ref Hero hero, SkillObject skill, ref float __result)
        {
            try
            {
                if (hero.IsPlayer()
                    && SettingsManager.LearningRateMultiplier.IsChanged)
                {
                    __result *= SettingsManager.LearningRateMultiplier.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(LearningRateMultiplier));
            }
        }
    }
}
