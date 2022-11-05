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
    public static class NeverKnockedBackByAttacks
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
                if (victimAgent.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.NeverKnockedBackByAttacks == true)
                {
                    blow.BlowFlag &= ~BlowFlags.KnockDown;
                    blow.BlowFlag &= ~BlowFlags.KnockBack;
                    blow.BlowFlag |= BlowFlags.ShrugOff;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NeverKnockedBackByAttacks));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.DecideAgentKnockedBackByBlow))]
    public static class NeverKnockedBackByAttacks_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideAgentKnockedByBlow(
            ref Agent attackerAgent,
            ref Agent victimAgent,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref Blow blow)
            => NeverKnockedBackByAttacks.DecideAgentKnockedByBlow(
                ref attackerAgent,
                ref victimAgent,
                ref collisionData,
                ref attackerWeapon,
                ref blow);
    }

    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideAgentKnockedBackByBlow))]
    public static class NeverKnockedBackByAttacks_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideAgentKnockedByBlow(
            ref Agent attackerAgent,
            ref Agent victimAgent,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref Blow blow)
            => NeverKnockedBackByAttacks.DecideAgentKnockedByBlow(
                ref attackerAgent,
                ref victimAgent,
                ref collisionData,
                ref attackerWeapon,
                ref blow);
    }
}
