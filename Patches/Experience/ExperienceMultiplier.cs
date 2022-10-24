using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultGenericXpModel), nameof(DefaultGenericXpModel.GetXpMultiplier))]
    public static class ExperienceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetXpMultiplier(Hero hero, ref float result)
        {
            try
            {
                if (hero.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.ExperienceMultiplier > 1f)
                {
                    result *= BannerlordCheatsSettings.Instance.ExperienceMultiplier;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ExperienceMultiplier));
            }
        }
    }
}
