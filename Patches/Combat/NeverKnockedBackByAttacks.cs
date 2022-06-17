using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{/*
    [HarmonyPatch(typeof(Mission), "DecideAgentKnockedByBlow")]
    public static class NeverKnockedBackByAttacks
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideAgentKnockedByBlow(
            ref Agent attacker,
            ref Agent victim,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref bool isInitialBlowShrugOff,
            ref Blow blow)
        {
            try
            {
                if (victim.IsPlayer()
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
*/}
