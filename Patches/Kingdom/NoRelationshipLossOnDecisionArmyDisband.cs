using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultDiplomacyModel), nameof(DefaultDiplomacyModel.GetRelationCostOfDisbandingArmy))]
    public static class NoRelationshipLossOnDecisionArmyDisband
    {
        [HarmonyPostfix]
        public static void GetRelationCostOfDisbandingArmy(bool isLeaderParty, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance?.NoRelationshipLossOnDecision == true)
            {
                __result = 0;
            }
        }
    }
}
