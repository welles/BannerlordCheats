using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.MilitiaChange), MethodType.Getter)]
    public static class DailyMilitiaBonusTown
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void MilitiaChange(ref Town __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerTown()
                    && SettingsManager.DailyMilitiaBonus.IsChanged)
                {
                    __result += SettingsManager.DailyMilitiaBonus.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyMilitiaBonusTown));
            }
        }
    }
}
