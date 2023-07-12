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
    [HarmonyPatch(typeof(DefaultPartyTroopUpgradeModel), nameof(DefaultPartyTroopUpgradeModel.GetGoldCostForUpgrade))]
    public static class FreeTroopUpgrades
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetGoldCostForUpgrade(ref PartyBase party, ref CharacterObject characterObject, ref CharacterObject upgradeTarget, ref int __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.FreeTroopUpgrades.IsChanged)
                {
                    __result = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(FreeTroopUpgrades));
            }
        }
    }
}
