using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultPregnancyModel), nameof(DefaultPregnancyModel.GetDailyChanceOfPregnancyForHero))]
    public static class PregnancyChanceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetDailyChanceOfPregnancyForHero(
            ref Hero hero,
            ref float __result)
        {
            try
            {
                if (SettingsManager.PregnancyChanceMultiplier.IsChanged
                    && (hero.IsPlayer() || hero.Spouse.IsPlayer()))
                {
                    __result *= SettingsManager.PregnancyChanceMultiplier.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PregnancyChanceMultiplier));
            }
        }

    }
}
