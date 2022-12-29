using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Village), nameof(Village.HearthChange), MethodType.Getter)]
    public static class DailyHearthsBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void HearthChange(ref Village __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerVillage()
                    && SettingsManager.DailyHearthsBonus.IsChanged)
                {
                    __result += SettingsManager.DailyHearthsBonus.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyHearthsBonus));
            }
        }
    }
}
