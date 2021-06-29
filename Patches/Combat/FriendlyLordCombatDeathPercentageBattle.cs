using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class FriendlyLordCombatDeathPercentageBattle
    {
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            if (effectedAgent.IsHero()
                &&effectedAgent.IsPlayerAlly()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.FriendlyLordCombatDeathPercentage, out var friendlyLordCombatDeathPercentage))
            {
                var factor = friendlyLordCombatDeathPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
