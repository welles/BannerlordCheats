﻿using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.DecideAgentKnockedBackByBlow))]
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideAgentKnockedBackByBlow))]
    public static class NeverKnockedBackByAttacks
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideAgentKnockedByBlow(
            ref Agent attackerAgent,
            ref Agent victimAgent,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref Blow blow)
        {
            try
            {
                if (!victimAgent.IsPlayer()
                    || BannerlordCheatsSettings.Instance?.NeverKnockedBackByAttacks != true) return;
                blow.BlowFlag &= ~BlowFlags.KnockDown;
                blow.BlowFlag &= ~BlowFlags.KnockBack;
                blow.BlowFlag |= BlowFlags.ShrugOff;
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NeverKnockedBackByAttacks));
            }
        }
    }
}
