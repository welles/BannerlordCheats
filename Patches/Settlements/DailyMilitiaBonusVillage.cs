using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Village), nameof(Village.MilitiaChange), MethodType.Getter)]
    public static class DailyMilitiaBonusVillage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void MilitiaChange(ref Village __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerVillage()
                    && SettingsManager.DailyMilitiaBonus.IsChanged)
                {
                    __result += SettingsManager.DailyMilitiaBonus.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyMilitiaBonusVillage));
            }
        }
    }
}
