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
    public static class NoFriendlyFire
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
                    && attackInformation.IsFriendlyFire
                    && SettingsManager.NoFriendlyFire.IsChanged)
                {
                    __result = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoFriendlyFire));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.CalculateDamage))]
    public static class NoFriendlyFire_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDamage(
            ref AttackInformation attackInformation,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData weapon,
            ref float __result)
            => NoFriendlyFire.CalculateDamage(
                ref attackInformation,
                ref collisionData,
                ref weapon,
                ref __result);
    }

    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class NoFriendlyFire_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDamage(
            ref AttackInformation attackInformation,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData weapon,
            ref float __result)
            => NoFriendlyFire.CalculateDamage(
                ref attackInformation,
                ref collisionData,
                ref weapon,
                ref __result);
    }
}
