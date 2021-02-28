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
            if ((__instance?.Owner?.Owner?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.DailyProsperityBonus > 0)
            {
                __result += BannerlordCheatsSettings.Instance.DailyProsperityBonus;
            }
        }
    }
}
