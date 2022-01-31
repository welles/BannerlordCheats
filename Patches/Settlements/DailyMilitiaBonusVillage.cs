using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

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
                    && BannerlordCheatsSettings.Instance?.DailyMilitiaBonus > 0)
                {
                    __result += BannerlordCheatsSettings.Instance.DailyMilitiaBonus;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyMilitiaBonusVillage));
            }
        }
    }
}
