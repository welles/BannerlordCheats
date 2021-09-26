using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultDiplomacyModel), nameof(DefaultDiplomacyModel.GetRelationCostOfExpellingClanFromKingdom))]
    public static class NoRelationshipLossOnDecisionExpellingClan
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRelationCostOfExpellingClanFromKingdom(ref int __result)
        {
            if (BannerlordCheatsSettings.Instance?.NoRelationshipLossOnDecision == true)
            {
                __result = 0;
            }
        }
    }
}
