﻿using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateRenownGain))]
    public static class RenownRewardMultiplierBattle
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateRenownGain(
            ref PartyBase party,
            ref float renownValueOfBattle,
            ref float contributionShare,
            ref ExplainedNumber result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.RenownRewardMultiplier > 1f)
                {
                    result.AddMultiplier(BannerlordCheatsSettings.Instance.RenownRewardMultiplier);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(RenownRewardMultiplierBattle));
            }
        }
    }
}
