using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Mission), nameof(Mission.DoesMissionRequireCivilianEquipment), MethodType.Getter)]
    public static class NeverRequireCivilianEquipment
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DoesMissionRequireCivilianEquipment(ref Mission __instance, ref bool __result)
        {
            try
            {
                if (SettingsManager.NeverRequireCivilianEquipment.IsChanged)
                {
                    __result = false;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NeverRequireCivilianEquipment));
            }
        }
    }
}
