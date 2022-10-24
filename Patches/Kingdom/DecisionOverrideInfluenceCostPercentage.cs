﻿using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultClanPoliticsModel), nameof(DefaultClanPoliticsModel.GetInfluenceRequiredToOverrideKingdomDecision))]
    public static class DecisionOverrideInfluenceCostPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetInfluenceRequiredToOverrideKingdomDecision(
            ref DecisionOutcome popularOption,
            ref DecisionOutcome overridingOption,
            ref KingdomDecision decision,
            ref int result)
        {
            try
            {
                if (!(BannerlordCheatsSettings.Instance?.DecisionOverrideInfluenceCostPercentage < 100f)) return;
                var factor = BannerlordCheatsSettings.Instance.DecisionOverrideInfluenceCostPercentage / 100.0f;

                var newValue = result * factor;

                result = (int) Math.Round(newValue);
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DecisionOverrideInfluenceCostPercentage));
            }
        }
    }
}
