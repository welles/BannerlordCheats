using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.GarrisonChange), MethodType.Getter)]
    public static class DailyGarrisonBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GarrisonChange(ref Town __instance, ref int __result)
        {
            try
            {
                if (__instance.IsPlayerTown()
                    && SettingsManager.DailyGarrisonBonus.IsChanged)
                {
                    __result += SettingsManager.DailyGarrisonBonus.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyGarrisonBonus));
            }
        }
    }
}
