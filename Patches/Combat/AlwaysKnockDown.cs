using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Mission), "DecideAgentKnockedByBlow")]
    public static class AlwaysKnockDown
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
                if (attacker.IsPlayer()
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
