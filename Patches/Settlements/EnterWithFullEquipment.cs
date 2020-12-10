using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Mission), nameof(Mission.DoesMissionRequireCivilianEquipment), MethodType.Getter)]
    public static class EnterWithFullEquipment
    {
        [HarmonyPostfix]
        public static void DoesMissionRequireCivilianEquipment(ref Mission __instance, ref bool __result)
        {
            if (BannerlordCheatsSettings.Instance.NeverRequireCivilianEquipment)
            {
                __result = false;
            }
        }
    }
}
