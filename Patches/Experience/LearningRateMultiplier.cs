using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.CalculateLearningRate), new[] { typeof(Hero), typeof(SkillObject) })]
    public static class LearningRateMultiplier
    {
        [HarmonyPostfix]
        public static void CalculateLearningRate(ref Hero hero, SkillObject skill, ref float __result)
        {
            if (hero.IsPlayer()
                && BannerlordCheatsSettings.Instance?.LearningRateMultiplier > 1f)
            {
                __result *= BannerlordCheatsSettings.Instance.LearningRateMultiplier;
            }
        }
    }
}
