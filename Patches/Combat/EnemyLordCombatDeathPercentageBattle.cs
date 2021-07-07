using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyLordCombatDeathPercentageBattle
    {
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            if (effectedAgent.IsHero()
                && effectedAgent.IsPlayerEnemy()
                && BannerlordCheatsSettings.Instance?.EnemyLordCombatDeathPercentage < 100f)
            {
                var factor = BannerlordCheatsSettings.Instance.EnemyLordCombatDeathPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
