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
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.CompanionLearningRateMultiplier, out var companionLearningRateMultiplier)
                && (hero?.IsPlayerCompanion ?? false))
            {
                __result *= companionLearningRateMultiplier;
            }
        }
    }
}
