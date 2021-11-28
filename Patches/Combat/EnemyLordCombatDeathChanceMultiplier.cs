using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyLordCombatDeathChanceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            if (effectedAgent.IsHero()
                && effectedAgent.IsPlayerEnemy()
                && BannerlordCheatsSettings.Instance?.EnemyLordCombatDeathChanceMultiplier > 1.0f)
            {
                __result *= BannerlordCheatsSettings.Instance.EnemyLordCombatDeathChanceMultiplier;
            }
        }
    }
}
