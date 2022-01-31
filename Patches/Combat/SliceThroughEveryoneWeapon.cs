using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Mission), "DecideWeaponCollisionReaction")]
    public static class SliceThroughEveryoneWeapon
    {
        [UsedImplicitly]
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
            try
            {
                if (attacker.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.SliceThroughEveryone == true)
                {
                    colReaction = MeleeCollisionReaction.SlicedThrough;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(SliceThroughEveryoneWeapon));
            }
        }
    }
}
