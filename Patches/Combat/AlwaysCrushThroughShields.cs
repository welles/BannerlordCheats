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
    public static class AlwaysCrushThroughShields
    {
        public static void DecideCrushedThrough(
            ref Agent attackerAgent,
            ref Agent defenderAgent,
            ref float totalAttackEnergy,
            ref Agent.UsageDirection attackDirection,
            ref StrikeType strikeType,
            ref WeaponComponentData defendItem,
            ref bool isPassiveUsage,
            ref bool __result)
        {
            try
            {
                if (attackerAgent.IsPlayer()
                    && SettingsManager.AlwaysCrushThroughShields.IsChanged)
                {
                    __result = true;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(AlwaysCrushThroughShields));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.DecideCrushedThrough))]
    public static class AlwaysCrushThroughShields_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideCrushedThrough(
            ref Agent attackerAgent,
            ref Agent defenderAgent,
            ref float totalAttackEnergy,
            ref Agent.UsageDirection attackDirection,
            ref StrikeType strikeType,
            ref WeaponComponentData defendItem,
            ref bool isPassiveUsage,
            ref bool __result)
            => AlwaysCrushThroughShields.DecideCrushedThrough(
                ref attackerAgent,
                ref defenderAgent,
                ref totalAttackEnergy,
                ref attackDirection,
                ref strikeType,
                ref defendItem,
                ref isPassiveUsage,
                ref __result);
    }

    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideCrushedThrough))]
    public static class AlwaysCrushThroughShields_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideCrushedThrough(
            ref Agent attackerAgent,
            ref Agent defenderAgent,
            ref float totalAttackEnergy,
            ref Agent.UsageDirection attackDirection,
            ref StrikeType strikeType,
            ref WeaponComponentData defendItem,
            ref bool isPassiveUsage,
            ref bool __result)
            => AlwaysCrushThroughShields.DecideCrushedThrough(
                ref attackerAgent,
                ref defenderAgent,
                ref totalAttackEnergy,
                ref attackDirection,
                ref strikeType,
                ref defendItem,
                ref isPassiveUsage,
                ref __result);
    }
}
