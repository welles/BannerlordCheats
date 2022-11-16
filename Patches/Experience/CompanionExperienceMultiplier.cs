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
    public static class CompanionExperienceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetXpMultiplier(ref Hero hero, ref float __result)
        {
            try
            {
                if (!hero.IsPlayer()
                    && hero.IsPlayerCompanion()
                    && SettingsManager.CompanionExperienceMultiplier.IsChanged)
                {
                    __result *= SettingsManager.CompanionExperienceMultiplier.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(CompanionExperienceMultiplier));
            }
        }
    }
}
