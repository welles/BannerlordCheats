﻿using System;
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
        public static void GetXpMultiplier(ref Hero hero, ref float result)
        {
            try
            {
                if (!hero.IsPlayer()
                    && hero.IsPlayerCompanion()
                    && BannerlordCheatsSettings.Instance?.CompanionExperienceMultiplier > 1f)
                {
                    result *= BannerlordCheatsSettings.Instance.CompanionExperienceMultiplier;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(CompanionExperienceMultiplier));
            }
        }
    }
}
