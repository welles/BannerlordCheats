using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), "OnWeaponAmountChange")]
    public static class PartyInfiniteAmmo
    {
        [HarmonyPrefix]
        public static void OnWeaponAmountChange(EquipmentIndex slotIndex, short amount, ref Agent __instance)
        {
            if (__instance != null
                && (Mission.Current?.PlayerTeam?.ActiveAgents.Contains(__instance) ?? false)
                && BannerlordCheatsSettings.Instance.PartyInfiniteAmmo)
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
