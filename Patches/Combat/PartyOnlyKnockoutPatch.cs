using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class PartyOnlyKnockoutPatch
    {
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            var playerTeam = Mission.Current?.Teams.SingleOrDefault(x => x.IsPlayerTeam)?.ActiveAgents;

            if (effectedAgent != null
                && playerTeam != null
                && playerTeam.Contains(effectedAgent)
                && BannerlordCheatsSettings.Instance.PartyOnlyKnockout)
            {
                __result = 0f;
            }
        }
    }
}
