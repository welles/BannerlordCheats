using System;
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
    public static class PartyOnlyKnockout
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            try
            {
                if (effectedAgent.Origin.TryGetParty(out var party)
                    && party.IsPlayerParty()
                    && !effectedAgent.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.PartyOnlyKnockout == true)
                {
                    __result = 0f;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyOnlyKnockout));
            }
        }
    }
}
