using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleMoraleModel), nameof(DefaultBattleMoraleModel.CalculateMoraleChangeToCharacter))]
    public static class EnemiesNoRunningAway
    {
        [HarmonyPostfix]
        public static void CalculateMoraleChangeToCharacter(Agent agent, float moraleChange, float distance, ref float __result)
        {
            if (agent.IsPlayerEnemy()
                && BannerlordCheatsSettings.Instance?.EnemiesNoRunningAway == true)
            {
                __result = 0.0f;
            }
        }
    }
}
