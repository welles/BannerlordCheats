using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultDiplomacyModel), nameof(DefaultDiplomacyModel.GetRelationCostOfDisbandingArmy))]
    public static class NoRelationshipLossOnArmyDisband
    {
        [HarmonyPostfix]
        public static void GetRelationCostOfDisbandingArmy(bool isLeaderParty, ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.NoRelationshipLossOnDecision, out var noRelationshipLossOnDecision)
                && noRelationshipLossOnDecision)
            {
                __result = 0;
            }
        }
    }
}
