using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class NoFriendlyLordCombatDeathPatch
    {
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            if (BannerlordCheatsSettings.Instance.FriendlyLordCombatDeathPercentage < 100.0f
                && effectedAgent.Character.IsHero
                && effectedAgent.Team.IsPlayerAlly)
            {
                var factor = BannerlordCheatsSettings.Instance.FriendlyLordCombatDeathPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
