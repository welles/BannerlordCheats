using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.ProsperityChange), MethodType.Getter)]
    public static class ProsperityPatch
    {
        [HarmonyPostfix]
        public static void ProsperityChange(ref Town __instance, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.DailyProsperityBonus, out var dailyProsperityBonus)
                && __instance.IsPlayerTown())
            {
                __result += dailyProsperityBonus;
            }
        }
    }
}
