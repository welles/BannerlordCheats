﻿using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartyHealingModel), nameof(DefaultPartyHealingModel.GetDailyHealingForRegulars))]
    public static class PartyHealingMultiplierTroops
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetDailyHealingForRegulars(ref MobileParty party, ref bool includeDescriptions, ref ExplainedNumber result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.PartyHealingMultiplier > 1f)
                {
                    result.AddMultiplier(BannerlordCheatsSettings.Instance.PartyHealingMultiplier);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyHealingMultiplierTroops));
            }
        }
    }
}
