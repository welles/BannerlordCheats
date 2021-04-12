using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyOnlyKnockout
    {
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.EnemyOnlyKnockout, out var enemyOnlyKnockout)
                && enemyOnlyKnockout
                && (Mission.Current?.PlayerEnemyTeam?.ActiveAgents.Contains(effectedAgent) ?? false))
            {
                __result = 0f;
            }
        }
    }
}
