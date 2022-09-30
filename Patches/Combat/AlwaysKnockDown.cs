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
    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.DecideAgentKnockedDownByBlow))]
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideAgentKnockedDownByBlow))]
    public static class AlwaysKnockDown
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideAgentKnockedByBlow(
            ref Agent attackerAgent,
            ref Agent victimAgent,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref Blow blow)
        {
            try
            {
                if (attackerAgent.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.AlwaysKnockDown == true)
                {
                    blow.BlowFlag &= ~BlowFlags.ShrugOff;
                    blow.BlowFlag |= BlowFlags.KnockDown;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(AlwaysKnockDown));
            }
        }
    }
}
