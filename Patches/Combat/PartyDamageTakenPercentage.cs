using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using BannerlordCheats.Extensions;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class PartyDamageTakenPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float __result)
        {
            try
            {
                if ( attackInformation.VictimAgentOrigin.TryGetParty(out var party)
                     && party.IsPlayerParty()
                     && !attackInformation.VictimAgentCharacter.IsPlayer()
                     && BannerlordCheatsSettings.Instance?.PartyDamageTakenPercentage < 100f)
                {
                    var factor = BannerlordCheatsSettings.Instance.PartyDamageTakenPercentage / 100f;

                    var newValue = (int)Math.Round(factor * __result);

                    __result = newValue;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyDamageTakenPercentage));
            }
        }
    }
}
