using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.DecideAgentKnockedBackByBlow))]
    public static class NeverKnockedBackByAttacks
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
                if (victimAgent.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.NeverKnockedBackByAttacks == true)
                {
                    blow.BlowFlag &= ~BlowFlags.KnockDown;
                    blow.BlowFlag &= ~BlowFlags.KnockBack;
                    blow.BlowFlag |= BlowFlags.ShrugOff;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NeverKnockedBackByAttacks));
            }
        }
    }
}
