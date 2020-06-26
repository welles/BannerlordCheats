using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), "OnWeaponAmountChange")]
    public static class InfiniteAmmo3
    {
        [HarmonyPrefix]
        public static void OnWeaponAmountChange(EquipmentIndex slotIndex, short amount, ref Agent __instance)
        {
            if ((__instance?.IsPlayerControlled ?? false)
                && BannerlordCheatsSettings.Instance.InfiniteAmmo)
            {
                var fullAmount = __instance.Equipment[slotIndex].MaxAmount;

                if (amount < fullAmount)
                {
                    __instance.SetWeaponAmountInSlot(slotIndex, fullAmount, false);
                }
            }
        }
    }
}
