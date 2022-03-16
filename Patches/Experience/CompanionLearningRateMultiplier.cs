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
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.CalculateLearningRate), typeof(Hero), typeof(SkillObject))]
    public static class CompanionLearningRateMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateLearningRate(ref Hero hero, ref SkillObject skill, ref float __result)
        {
            try
            {
                if (!hero.IsPlayer()
                    && hero.IsPlayerCompanion()
                    && BannerlordCheatsSettings.Instance?.CompanionLearningRateMultiplier > 1f)
                {
                    __result *= BannerlordCheatsSettings.Instance.CompanionLearningRateMultiplier;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(CompanionLearningRateMultiplier));
            }
        }
    }
}
