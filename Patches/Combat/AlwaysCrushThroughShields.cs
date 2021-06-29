using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideCrushedThrough))]
    public class AlwaysCrushThroughShields
    {
        [HarmonyPostfix]
        public static void DecideCrushedThrough(Agent attackerAgent, Agent defenderAgent, float totalAttackEnergy, Agent.UsageDirection attackDirection, StrikeType strikeType, WeaponComponentData defendItem, bool isPassiveUsage, ref bool __result)
        {
            if (attackerAgent.IsPlayer()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.AlwaysCrushThroughShields, out var alwaysCrushThroughShields)
                && alwaysCrushThroughShields)
            {
                __result = true;
            }
        }
    }
}
