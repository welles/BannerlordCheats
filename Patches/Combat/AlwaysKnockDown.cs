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
    public static class AlwaysKnockDown
    {
        public static void DecideAgentKnockedByBlow(
            ref Agent attackerAgent,
            ref Agent victimAgent,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref Blow blow)
        {
            try
            {
                if (attackerAgent.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.AlwaysKnockDown == true)
                {
                    blow.BlowFlag &= ~BlowFlags.ShrugOff;
                    blow.BlowFlag |= BlowFlags.KnockDown;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(AlwaysKnockDown));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.DecideAgentKnockedDownByBlow))]
    public static class AlwaysKnockDown_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideAgentKnockedByBlow(
            ref Agent attackerAgent,
            ref Agent victimAgent,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref Blow blow)
            => AlwaysKnockDown.DecideAgentKnockedByBlow(
                ref attackerAgent,
                ref victimAgent,
                ref collisionData,
                ref attackerWeapon,
                ref blow);
    }

    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideAgentKnockedDownByBlow))]
    public static class AlwaysKnockDown_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideAgentKnockedByBlow(
            ref Agent attackerAgent,
            ref Agent victimAgent,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref Blow blow)
            => AlwaysKnockDown.DecideAgentKnockedByBlow(
                ref attackerAgent,
                ref victimAgent,
                ref collisionData,
                ref attackerWeapon,
                ref blow);
    }
}
