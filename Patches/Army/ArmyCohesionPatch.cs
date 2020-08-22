using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(Army), nameof(Army.CohesionChange), MethodType.Getter)]
    public static class ArmyCohesionPatch
    {
        [HarmonyPostfix]
        public static void CohesionChange(ref Army __instance, ref float __result)
        {
            if (__instance != null
                && __instance.Parties.Any(x => x?.IsMainParty ?? false))
            {
                var factor = BannerlordCheatsSettings.Instance.ArmyCohesionLossPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
