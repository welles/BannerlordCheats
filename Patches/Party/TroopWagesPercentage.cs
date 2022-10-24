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
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTotalWage))]
    public static class TroopWagesPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetTotalWage(ref MobileParty mobileParty, ref bool includeDescriptions, ref ExplainedNumber result)
        {
            try
            {
                if (mobileParty.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.TroopWagesPercentage < 100f)
                {
                    result.AddPercentage(BannerlordCheatsSettings.Instance.TroopWagesPercentage);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(TroopWagesPercentage));
            }
        }
    }
}
