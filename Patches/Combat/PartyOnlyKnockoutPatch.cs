using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class PartyOnlyKnockoutPatch
    {
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            if (effectedAgent.Origin.TryGetParty(out var party)
                && party.IsPlayerParty()
                && !effectedAgent.IsPlayer()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.PartyOnlyKnockout, out var partyOnlyKnockout)
                && partyOnlyKnockout)
            {
                __result = 0f;
            }
        }
    }
}
