using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(Town), "Construction", MethodType.Getter)]
    public static class OneDayConstructionPatch
    {
        [HarmonyPostfix]
        public static void Construction(ref Town __instance, ref float __result)
        {
            if ((__instance?.Owner?.Owner?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.OneDayConstruction)
            {
                __result = float.MaxValue;
            }
        }
    }
}
