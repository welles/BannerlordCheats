using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.SecurityChange), MethodType.Getter)]
    public static class DailySecurityBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void SecurityChange(ref Town __instance, ref float __result)
        {
            if (__instance.IsPlayerTown()
                && BannerlordCheatsSettings.Instance?.DailySecurityBonus > 0)
            {
                __result += BannerlordCheatsSettings.Instance.DailySecurityBonus;
            }
        }
    }
}
