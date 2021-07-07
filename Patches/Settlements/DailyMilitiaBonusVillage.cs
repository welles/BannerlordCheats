using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Village), nameof(Village.MilitiaChange), MethodType.Getter)]
    public static class DailyMilitiaBonusVillage
    {
        [HarmonyPostfix]
        public static void MilitiaChange(ref Village __instance, ref float __result)
        {
            if (__instance.IsPlayerVillage()
                && BannerlordCheatsSettings.Instance?.DailyMilitiaBonus > 0)
            {
                __result += BannerlordCheatsSettings.Instance.DailyMilitiaBonus;
            }
        }
    }
}
