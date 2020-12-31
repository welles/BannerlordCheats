using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using System;
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
            if ((attackInformation.IsVictimAgentMine || (attackInformation.IsVictimAgentMount && attackInformation.IsVictimAgentRiderAgentMine))
                && !BannerlordCheatsSettings.Instance.Invincible)
            {
                var factor = BannerlordCheatsSettings.Instance.DamageTakenPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
