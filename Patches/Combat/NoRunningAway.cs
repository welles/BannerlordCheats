using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleMoraleModel), nameof(DefaultBattleMoraleModel.CalculateMoraleChangeToCharacter))]
    public static class NoRunningAway
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateMoraleChangeToCharacter(Agent agent, float moraleChange, float distance, ref float __result)
        {
            if (agent.Origin.TryGetParty(out var party)
                && party.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.NoRunningAway == true)
            {
                __result = 0.0f;
            }
        }
    }
}
