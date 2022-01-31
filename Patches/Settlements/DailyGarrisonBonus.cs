using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

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
                    && BannerlordCheatsSettings.Instance?.DailyGarrisonBonus > 0)
                {
                    __result += BannerlordCheatsSettings.Instance.DailyGarrisonBonus;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyGarrisonBonus));
            }
        }
    }
}
