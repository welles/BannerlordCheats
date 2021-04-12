using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Mission), "DecideAgentKnockedByBlow")]
    public static class AlwaysKnockDownPatch
    {
        [HarmonyPostfix]
        public static void DecideAgentKnockedByBlow(
            ref Agent attacker,
            ref Agent victim,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref bool isInitialBlowShrugOff,
            ref Blow blow)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.AlwaysKnockDown, out var alwaysKnockDown)
                && alwaysKnockDown
                && attacker.IsPlayer())
            {
                blow.BlowFlag &= ~BlowFlags.ShrugOff;
                blow.BlowFlag |= BlowFlags.KnockDown;
            }
        }
    }
}
