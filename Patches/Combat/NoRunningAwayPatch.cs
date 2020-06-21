using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleMoraleModel), nameof(DefaultBattleMoraleModel.CalculateMoraleChangeToCharacter))]
    public static class NoRunningAwayPatch
    {
        [HarmonyPostfix]
        public static void CalculateMoraleChangeToCharacter(Agent agent, float moraleChange, float distance, ref float __result)
        {
            if (agent != null
                && agent.Team != null
                && agent.Team.IsPlayerTeam
                && BannerlordCheatsSettings.Instance.NoRunningAway)
            {
                __result = 0.0f;
            }
        }
    }
}
