﻿using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class DamageMultiplier
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float __result)
        {
            if (attackInformation.AttackerAgentCharacter.IsPlayer()
                && !attackInformation.IsFriendlyFire
                && BannerlordCheatsSettings.Instance?.DamageMultiplier > 1f)
            {
                __result *= BannerlordCheatsSettings.Instance.DamageMultiplier;
            }
        }
    }

}
