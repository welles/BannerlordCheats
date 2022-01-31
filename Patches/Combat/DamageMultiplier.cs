using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class DamageMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float __result)
        {
            try
            {
                if (attackInformation.AttackerAgentCharacter.IsPlayer()
                    && !attackInformation.IsFriendlyFire
                    && BannerlordCheatsSettings.Instance?.DamageMultiplier > 1f)
                {
                    __result *= BannerlordCheatsSettings.Instance.DamageMultiplier;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DamageMultiplier));
            }
        }
    }

}
