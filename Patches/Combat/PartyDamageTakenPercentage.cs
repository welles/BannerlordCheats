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
    public static class PartyDamageTakenPercentage
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.PartyDamageTakenPercentage, out var partyDamageTakenPercentage)
                && attackInformation.VictimAgentOrigin.TryGetParty(out var party)
                && party.IsPlayerParty()
                && !attackInformation.VictimAgentCharacter.IsPlayer())
            {
                var factor = partyDamageTakenPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
