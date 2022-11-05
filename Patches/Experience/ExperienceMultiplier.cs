using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using StoryMode.GameComponents;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Experience
{
    public static class ExperienceMultiplier
    {
        public static void GetXpMultiplier(
            ref Hero hero,
            ref float __result)
        {
            try
            {
                if (hero.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.ExperienceMultiplier > 1f)
                {
                    __result *= BannerlordCheatsSettings.Instance.ExperienceMultiplier;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ExperienceMultiplier));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultGenericXpModel), nameof(DefaultGenericXpModel.GetXpMultiplier))]
    public static class ExperienceMultiplier_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetXpMultiplier(
            ref Hero hero,
            ref float __result)
            => ExperienceMultiplier.GetXpMultiplier(ref hero, ref __result);
    }



    [HarmonyPatch(typeof(StoryModeGenericXpModel), nameof(StoryModeGenericXpModel.GetXpMultiplier))]
    public static class ExperienceMultiplier_StoryMode
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetXpMultiplier(
            ref Hero hero,
            ref float __result)
            => ExperienceMultiplier.GetXpMultiplier(ref hero, ref __result);
    }
}
