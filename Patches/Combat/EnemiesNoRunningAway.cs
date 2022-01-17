using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxBattleMoraleModel), nameof(SandboxBattleMoraleModel.CalculateMoraleChangeToCharacter))]
    public static class EnemiesNoRunningAway
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateMoraleChangeToCharacter(
            ref Agent agent,
            ref float maxMoraleChange,
            ref float __result)
        {
            if (agent.IsPlayerEnemy()
                && BannerlordCheatsSettings.Instance?.EnemiesNoRunningAway == true)
            {
                __result = 0.0f;
            }
        }
    }
}
