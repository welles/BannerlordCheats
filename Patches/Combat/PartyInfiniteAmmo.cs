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
    public static class PartyInfiniteAmmo
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
                if (!shooterAgent.IsPlayer()
                    && shooterAgent.Origin.TryGetParty(out var party)
                    && party.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.PartyInfiniteAmmo == true)
                {
                    for (var index = EquipmentIndex.WeaponItemBeginSlot; index < EquipmentIndex.NumAllWeaponSlots; ++index)
                    {
                        var missionWeapon = shooterAgent.Equipment[index];

                        if (missionWeapon.IsAnyConsumable(out _)
                            && missionWeapon.Amount <= missionWeapon.ModifiedMaxAmount)
                        {
                            shooterAgent.SetWeaponAmountInSlot(index, missionWeapon.ModifiedMaxAmount, true);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyInfiniteAmmo));
            }
        }
    }
}
