﻿using System;
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
            ref float result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.PregnancyChanceMultiplier > 1.0f
                    && (hero.IsPlayer() || hero.Spouse.IsPlayer()))
                {
                    result *= BannerlordCheatsSettings.Instance.PregnancyChanceMultiplier;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PregnancyChanceMultiplier));
            }
        }

    }
}
