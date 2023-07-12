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
    public static class DamageMultiplier
    {
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, ref WeaponComponentData weapon, ref float __result)
        {
            try
            {
                if (attackInformation.IsAttackerPlayer
                    && !attackInformation.IsFriendlyFire
                    && SettingsManager.DamageMultiplier.IsChanged)
                {
                    __result *= SettingsManager.DamageMultiplier.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DamageMultiplier));
            }
        }
    }

    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class DamageMultiplier_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, ref WeaponComponentData weapon, ref float __result)
            => DamageMultiplier.CalculateDamage(ref attackInformation, ref collisionData, ref weapon, ref __result);
    }
}
