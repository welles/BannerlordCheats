using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultDiplomacyModel), nameof(DefaultDiplomacyModel.GetRelationCostOfDisbandingArmy))]
    public static class NoRelationshipLossOnDecisionArmyDisband
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRelationCostOfDisbandingArmy(bool isLeaderParty, ref int result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.NoRelationshipLossOnDecision == true)
                {
                    result = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoRelationshipLossOnDecisionArmyDisband));
            }
        }
    }
}
