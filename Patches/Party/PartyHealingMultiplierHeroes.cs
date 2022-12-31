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
    [HarmonyPatch(typeof(DefaultPartyHealingModel), nameof(DefaultPartyHealingModel.GetDailyHealingHpForHeroes))]
    public static class PartyHealingMultiplierHeroes
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetDailyHealingHpForHeroes(ref MobileParty party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.PartyHealingMultiplier.IsChanged)
                {
                    __result.AddMultiplier(SettingsManager.PartyHealingMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyHealingMultiplierHeroes));
            }
        }
    }
}
