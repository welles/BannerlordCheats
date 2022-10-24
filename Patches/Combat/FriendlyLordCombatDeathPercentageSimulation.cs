/*
using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Combat
{
    
    [HarmonyPatch(typeof(DefaultCombatSimulationModel), nameof(DefaultCombatSimulationModel.SimulateHit))]
    public static class FriendlyLordCombatDeathPercentageSimulation
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void SimulateHit(ref CharacterObject strikerTroop, ref CharacterObject struckTroop, ref PartyBase strikerParty, ref PartyBase struckParty, ref float strikerAdvantage, ref MapEvent battle, ref int __result)
        {
            if (!struckTroop.IsHero()
                || !struckParty.IsPlayerKingdom()
                || !(BannerlordCheatsSettings.Instance?.FriendlyLordCombatDeathPercentage < 100f)) return;
            var factor = BannerlordCheatsSettings.Instance.FriendlyLordCombatDeathPercentage / 100f;

            __result = (int) Math.Round(__result / factor);
        }
    }
    
}
*/
