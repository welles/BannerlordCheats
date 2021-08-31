using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.LoyaltyChange), MethodType.Getter)]
    public static class DailyLoyaltyBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void LoyaltyChange(ref Town __instance, ref float __result)
        {
            if (__instance.IsPlayerTown()
                && BannerlordCheatsSettings.Instance?.DailyLoyaltyBonus > 0)
            {
                __result += BannerlordCheatsSettings.Instance.DailyLoyaltyBonus;
            }
        }
    }
}
