using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Election;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(KingdomElection), nameof(KingdomElection.GetRelationChangeWithSponsor))]
    public static class NoRelationshipLossOnDecisionKingdomDecision
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRelationChangeWithSponsor(Supporter.SupportWeights supportWeight, bool isOpposingSides, ref int result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.NoRelationshipLossOnDecision == true)
                {
                    result = Math.Max(result, 0);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoRelationshipLossOnDecisionKingdomDecision));
            }
        }
    }
}
