using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.GarrisonChange), MethodType.Getter)]
    public static class GarrisonGrowthPatch
    {
        [HarmonyPostfix]
        public static void GarrisonChange(ref Town __instance, ref int __result)
        {
            if (__instance.IsPlayerTown()
                && BannerlordCheatsSettings.Instance.DailyGarrisonBonus > 0)
            {
                __result += BannerlordCheatsSettings.Instance.DailyGarrisonBonus;
            }
        }
    }
}
