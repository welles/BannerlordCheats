using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.Multiplayer;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), "OnWeaponAmountChange")]
    public static class InfiniteAmmoValue
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

    [HarmonyPatch(typeof(MissionAgentStatusVM), nameof(MissionAgentStatusVM.ShowAmmoCount), MethodType.Getter)]
    public static class InfiniteAmmoVM
    {
        [HarmonyPostfix]
        public static void ShowAmmoCount(ref MissionAgentStatusVM __instance, ref bool __result)
        {
            if (BannerlordCheatsSettings.Instance.InfiniteAmmo)
            {
                __result = false;
            }
        }
    }
}
