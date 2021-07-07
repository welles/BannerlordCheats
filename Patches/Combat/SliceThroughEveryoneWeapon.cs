using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Mission), "DecideWeaponCollisionReaction")]
    public static class SliceThroughEveryoneWeapon
    {
        [HarmonyPostfix]
        public static void DecideWeaponCollisionReaction(
            ref Blow registeredBlow,
            ref AttackCollisionData collisionData,
            ref Agent attacker,
            ref Agent defender,
            ref MissionWeapon attackerWeapon,
            ref bool isFatalHit,
            ref bool isShruggedOff,
            ref MeleeCollisionReaction colReaction)
        {
            if (attacker.IsPlayer()
                && BannerlordCheatsSettings.Instance?.SliceThroughEveryone == true)
            {
                colReaction = MeleeCollisionReaction.SlicedThrough;
            }
        }
    }
}
