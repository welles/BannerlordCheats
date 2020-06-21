using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideCrushedThrough))]
    public class AlwaysCrushThrough
    {
        [HarmonyPostfix]
        public static void DecideCrushedThrough(Agent attackerAgent, Agent defenderAgent, float totalAttackEnergy, float defenderStunPeriod, float impactPoint, ref bool __result)
        {
            if ((attackerAgent?.IsPlayerControlled ?? false)
                && BannerlordCheatsSettings.Instance.AlwaysCrushThroughShields)
            {
                __result = true;
            }
        }
    }
}
