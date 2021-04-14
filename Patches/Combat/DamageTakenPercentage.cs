using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using System;
using BannerlordCheats.Extensions;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class DamageTakenFactor
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float __result)
        {
            if (attackInformation.VictimAgentCharacter.IsPlayer()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.DamageTakenPercentage, out var damageTakenPercentage))
            {
                var factor = damageTakenPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
