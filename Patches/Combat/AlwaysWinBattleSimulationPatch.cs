using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultCombatSimulationModel), nameof(DefaultCombatSimulationModel.SimulateHit))]
    public static class AlwaysWinBattleSimulationPatch
    {
        [HarmonyPostfix]
        public static void SimulateHit(ref CharacterObject strikerTroop, ref CharacterObject struckTroop, ref PartyBase strikerParty, ref PartyBase struckParty, ref float strikerAdvantage, ref MapEvent battle, ref int __result)
        {
            if (struckParty.IsPlayerParty()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.AlwaysWinBattleSimulation, out var alwaysWinBattleSimulation)
                && alwaysWinBattleSimulation)
            {
                __result = 0;
            }
        }
    }
}
