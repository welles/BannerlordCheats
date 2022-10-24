using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.DecideCrushedThrough))]
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideCrushedThrough))]
    public class AlwaysCrushThroughShields
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideCrushedThrough(Agent attackerAgent, Agent defenderAgent, float totalAttackEnergy, Agent.UsageDirection attackDirection, StrikeType strikeType, WeaponComponentData defendItem, bool isPassiveUsage, ref bool result)
        {
            try
            {
                if (attackerAgent.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.AlwaysCrushThroughShields == true)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(AlwaysCrushThroughShields));
            }
        }
    }
}
