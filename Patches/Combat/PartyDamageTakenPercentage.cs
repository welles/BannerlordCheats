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
    public static class PartyDamageTakenPercentage
    {
        public static void CalculateDamage(
            ref AttackInformation attackInformation,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData weapon,
            ref float __result)
        {
            try
            {
                if ( attackInformation.VictimAgentOrigin.TryGetParty(out var party)
                     && party.IsPlayerParty()
                     && !attackInformation.IsVictimPlayer
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

    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.CalculateDamage))]
    public static class PartyDamageTakenPercentage_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDamage(
            ref AttackInformation attackInformation,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData weapon,
            ref float __result)
            => PartyDamageTakenPercentage.CalculateDamage(
                ref attackInformation,
                ref collisionData,
                ref weapon,
                ref __result);
    }

    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class PartyDamageTakenPercentage_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDamage(
            ref AttackInformation attackInformation,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData weapon,
            ref float __result)
            => PartyDamageTakenPercentage.CalculateDamage(
                ref attackInformation,
                ref collisionData,
                ref weapon,
                ref __result);
    }
}
