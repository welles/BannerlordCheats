using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
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
            ref float result)
        {
            try
            {
                if (agent.IsPlayerEnemy()
                    && BannerlordCheatsSettings.Instance?.EnemiesNoRunningAway == true)
                {
                    result = 0.0f;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnemiesNoRunningAway));
            }
        }
    }
}
