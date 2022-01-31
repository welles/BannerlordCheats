using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

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
                    && BannerlordCheatsSettings.Instance?.DailyMilitiaBonus > 0)
                {
                    __result += BannerlordCheatsSettings.Instance.DailyMilitiaBonus;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyMilitiaBonusTown));
            }
        }
    }
}
