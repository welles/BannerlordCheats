using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(HeroDeveloper), nameof(HeroDeveloper.AddSkillXp))]
    public static class CompanionExperienceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static void AddSkillXp(
            ref SkillObject skill,
            ref float rawXp,
            ref bool isAffectedByFocusFactor,
            ref bool shouldNotify,
            ref HeroDeveloper __instance)
        {
            if (__instance.Hero.IsPlayerCompanion()
                && SettingsManager.CompanionExperienceMultiplier.IsChanged)
            {
                rawXp *= SettingsManager.CompanionExperienceMultiplier.Value;
            }
        }
    }
}
