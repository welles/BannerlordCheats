using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem.Election;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(KingdomElection), nameof(KingdomElection.GetRelationChangeWithSponsor))]
    public static class NoRelationshipLossOnDecisionKingdomDecision
    {
        [HarmonyPostfix]
        public static void GetRelationChangeWithSponsor(Supporter.SupportWeights supportWeight, bool isOpposingSides, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance?.NoRelationshipLossOnDecision == true)
            {
                __result = Math.Max(__result, 0);
            }
        }
    }
}
