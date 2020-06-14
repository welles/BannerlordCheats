using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultCombatSimulationModel), "SimulateHit")]
    public static class AlwaysWinBattleSimulationPatch
    {
        [HarmonyPostfix]
        public static void SimulateHit(CharacterObject strikerTroop, CharacterObject strikedTroop, PartyBase strikerParty, PartyBase strikedParty, float strikerAdvantage, MapEvent battle, ref int __result)
        {
            if ((strikedParty?.Leader?.IsPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.AlwaysWinBattleSimulation)
            {
                __result = 0;
            }
        }
    }
}
