using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentDecideKilledOrUnconsciousModel), nameof(SandboxAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyLordCombatDeathChanceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            try
            {
                if (effectedAgent.IsHero()
                    && effectedAgent.IsPlayerEnemy()
                    && BannerlordCheatsSettings.Instance?.EnemyLordCombatDeathChanceMultiplier > 1.0f)
                {
                    __result *= BannerlordCheatsSettings.Instance.EnemyLordCombatDeathChanceMultiplier;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnemyLordCombatDeathChanceMultiplier));
            }
        }
    }
}
