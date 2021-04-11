using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.CalculateLearningRate), typeof(Hero), typeof(SkillObject))]
    public static class CompanionLearningRateMultiplierPatch
    {
        [HarmonyPostfix]
        public static void CalculateLearningRate(ref Hero hero, ref SkillObject skill, ref float __result)
        {
            if ((hero?.IsPlayerCompanion ?? false)
                && BannerlordCheatsSettings.Instance.CompanionLearningRateMultiplier > 1.0f)
            {
                __result *= BannerlordCheatsSettings.Instance.CompanionLearningRateMultiplier;
            }
        }
    }
}
