using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleMoraleModel), nameof(DefaultBattleMoraleModel.CalculateMoraleChangeToCharacter))]
    public static class EnemiesNoRunningAwayPatch
    {
        [HarmonyPostfix]
        public static void CalculateMoraleChangeToCharacter(Agent agent, float moraleChange, float distance, ref float __result)
        {
            if (agent != null
                && agent.Team != null
                && Agent.Main?.Team != null
                && agent.Team.IsEnemyOf(Agent.Main.Team)
                && BannerlordCheatsSettings.Instance.EnemiesNoRunningAway)
            {
                __result = 0.0f;
            }
        }
    }
}
