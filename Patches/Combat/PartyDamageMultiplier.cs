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
    public static class PartyDamageMultiplier
    {
        public static void CalculateDamage(
            ref AttackInformation attackInformation,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData weapon,
            ref float __result)
        {
            try
            {
                if (attackInformation.AttackerAgentOrigin.TryGetParty(out var party)
                    && party.IsPlayerParty()
                    && !attackInformation.IsAttackerPlayer
                    && !attackInformation.IsFriendlyFire
                    && SettingsManager.PartyDamageMultiplier.IsChanged)
                {
                    __result *= SettingsManager.PartyDamageMultiplier.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyDamageMultiplier));
            }
        }
    }

    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class PartyDamageMultiplier_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDamage(
            ref AttackInformation attackInformation,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData weapon,
            ref float __result)
            => PartyDamageMultiplier.CalculateDamage(
                ref attackInformation,
                ref collisionData,
                ref weapon,
                ref __result);
    }
}
