using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Mission), "OnAgentShootMissile")]
    public static class InfiniteAmmo
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnAgentShootMissile(
            ref Agent shooterAgent,
            ref EquipmentIndex weaponIndex,
            ref Vec3 position,
            ref Vec3 velocity,
            ref Mat3 orientation,
            ref bool hasRigidBody,
            ref bool isPrimaryWeaponShot,
            ref int forcedMissileIndex)
        {
            try
            {
                if (shooterAgent.IsPlayer()
                    && SettingsManager.InfiniteAmmo.IsChanged)
                {
                    for (var index = EquipmentIndex.WeaponItemBeginSlot; index < EquipmentIndex.NumAllWeaponSlots; ++index)
                    {
                        var missionWeapon = shooterAgent.Equipment[index];

                        if (missionWeapon.IsAnyConsumable()
                            && missionWeapon.Amount <= missionWeapon.ModifiedMaxAmount)
                        {
                            shooterAgent.SetWeaponAmountInSlot(index, missionWeapon.ModifiedMaxAmount, true);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(InfiniteAmmo));
            }
        }
    }
}
