using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.LoyaltyChange), MethodType.Getter)]
    public static class LoyaltyPatch
    {
        [HarmonyPostfix]
        public static void LoyaltyChange(ref Town __instance, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.DailyLoyaltyBonus, out var dailyLoyaltyBonus)
                && __instance.IsPlayerTown())
            {
                __result += dailyLoyaltyBonus;
            }
        }
    }
}
