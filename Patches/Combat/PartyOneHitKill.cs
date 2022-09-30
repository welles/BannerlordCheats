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
    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.CalculateDamage))]
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class PartyOneHitKill
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float __result)
        {
            try
            {
                if (attackInformation.AttackerAgentOrigin.TryGetParty(out var party)
                    && party.IsPlayerParty()
                    && !attackInformation.AttackerAgentCharacter.IsPlayer()
                    && !attackInformation.IsFriendlyFire
                    && BannerlordCheatsSettings.Instance?.PartyOneHitKill == true)
                {
                    __result = 10000;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyOneHitKill));
            }
        }
    }
}
