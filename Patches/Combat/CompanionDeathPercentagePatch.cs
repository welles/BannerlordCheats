using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class CompanionDeathPercentagePatch
    {
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            if (BannerlordCheatsSettings.Instance.CompanionDeathPercentage < 100.0f
                && effectedAgent.Character.IsHero
                && !effectedAgent.Character.IsPlayer()
                && effectedAgent.Origin.TryGetParty(out var party)
                && party.IsPlayerParty())
            {
                var factor = BannerlordCheatsSettings.Instance.CompanionDeathPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
