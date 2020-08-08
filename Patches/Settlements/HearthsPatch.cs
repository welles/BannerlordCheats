using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Village), nameof(Village.HearthChange), MethodType.Getter)]
    public static class HearthsPatch
    {
        [HarmonyPostfix]
        public static void HearthChange(ref Village __instance, ref float __result)
        {
            if ((__instance?.Owner?.Owner?.IsHumanPlayerCharacter ?? false))
            {
                __result += BannerlordCheatsSettings.Instance.DailyHearthsBonus;
            }
        }
    }
}
