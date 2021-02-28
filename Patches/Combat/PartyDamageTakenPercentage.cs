using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class PartyDamageTakenPercentage
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float __result)
        {
            if ((attackInformation.VictimFormation?.Team?.IsPlayerTeam ?? false)
                && !BannerlordCheatsSettings.Instance.PartyInvincible)
            {
                var factor = BannerlordCheatsSettings.Instance.PartyDamageTakenPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
