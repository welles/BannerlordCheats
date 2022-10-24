using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultDiplomacyModel), nameof(DefaultDiplomacyModel.GetRelationCostOfExpellingClanFromKingdom))]
    public static class NoRelationshipLossOnDecisionExpellingClan
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRelationCostOfExpellingClanFromKingdom(ref int result)
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
                SubModule.LogError(e, typeof(NoRelationshipLossOnDecisionExpellingClan));
            }
        }
    }
}
