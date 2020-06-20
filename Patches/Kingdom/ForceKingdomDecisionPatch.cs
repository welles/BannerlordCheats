using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem.Election;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DecisionOutcome), nameof(DecisionOutcome.TotalSupportPoints), MethodType.Getter)]
    public static class TotalSupportPoints
    {
        [HarmonyPostfix]
        public static void Getter(ref DecisionOutcome __instance, ref float __result)
        {
            if (__instance.SupporterList.Any(x => x.IsPlayer)
                && BannerlordCheatsSettings.Instance.ForceKingdomDecision)
            {
                __result = 10000;
            }
        }
    }
}
