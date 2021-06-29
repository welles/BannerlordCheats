using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultDiplomacyModel), nameof(DefaultDiplomacyModel.GetRelationCostOfExpellingClanFromKingdom))]
    public static class NoRelationshipLossOnDecisionExpellingClan
    {
        [HarmonyPostfix]
        public static void GetRelationCostOfExpellingClanFromKingdom(ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.NoRelationshipLossOnDecision, out var noRelationshipLossOnDecision)
                && noRelationshipLossOnDecision)
            {
                __result = 0;
            }
        }
    }
}
