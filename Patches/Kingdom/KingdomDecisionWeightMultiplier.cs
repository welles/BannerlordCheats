using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem.Election;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DecisionOutcome), nameof(DecisionOutcome.TotalSupportPoints), MethodType.Getter)]
    public static class KingdomDecisionWeightMultiplier
    {
        [HarmonyPostfix]
        public static void Getter(ref DecisionOutcome __instance, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.KingdomDecisionWeightMultiplier, out var kingdomDecisionWeightMultiplier)
                && __instance.SupporterList.Any(x => x.IsPlayer))
            {
                __result *= kingdomDecisionWeightMultiplier;
            }
        }
    }
}
