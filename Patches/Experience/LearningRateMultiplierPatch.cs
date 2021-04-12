using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.CalculateLearningRate), new[] { typeof(Hero), typeof(SkillObject) })]
    public static class LearningRateMultiplierPatch
    {
        [HarmonyPostfix]
        public static void CalculateLearningRate(ref Hero hero, SkillObject skill, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.LearningRateMultiplier, out var learningRateMultiplier)
                && hero.IsPlayer())
            {
                __result *= learningRateMultiplier;
            }
        }
    }
}
