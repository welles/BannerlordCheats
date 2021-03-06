﻿using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Mission), nameof(Mission.DoesMissionRequireCivilianEquipment), MethodType.Getter)]
    public static class NeverRequireCivilianEquipment
    {
        [HarmonyPostfix]
        public static void DoesMissionRequireCivilianEquipment(ref Mission __instance, ref bool __result)
        {
            if (BannerlordCheatsSettings.Instance?.NeverRequireCivilianEquipment == true)
            {
                __result = false;
            }
        }
    }
}
