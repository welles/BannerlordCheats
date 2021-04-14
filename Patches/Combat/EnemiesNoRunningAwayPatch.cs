using BannerlordCheats.Extensions;
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
            if (agent.IsPlayerEnemy()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.EnemiesNoRunningAway, out var enemiesNoRunningAway)
                && enemiesNoRunningAway)
            {
                __result = 0.0f;
            }
        }
    }
}
