using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class NoEnemyLordCombatDeathPatch
    {
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.EnemyLordCombatDeathPercentage, out var enemyLordCombatDeathPercentage)
                && effectedAgent.Character.IsHero
                && !effectedAgent.Team.IsPlayerAlly)
            {
                var factor = enemyLordCombatDeathPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
