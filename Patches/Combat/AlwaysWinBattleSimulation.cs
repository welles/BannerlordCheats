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
    public static class AlwaysWinBattleSimulation
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void SimulateHit(ref CharacterObject strikerTroop, ref CharacterObject struckTroop, ref PartyBase strikerParty, ref PartyBase struckParty, ref float strikerAdvantage, ref MapEvent battle, ref int __result)
        {
            try
            {
                if (struckParty.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.AlwaysWinBattleSimulation == true)
                {
                    __result = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(AlwaysWinBattleSimulation));
            }
        }
    }
}
