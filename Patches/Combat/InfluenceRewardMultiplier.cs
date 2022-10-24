using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateInfluenceGain))]
    public static class InfluenceRewardMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateInfluenceGain(
            ref PartyBase party,
            ref float influenceValueOfBattle,
            ref float contributionShare,
            ref ExplainedNumber result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.InfluenceRewardMultiplier > 1f)
                {
                    result.AddMultiplier(BannerlordCheatsSettings.Instance.InfluenceRewardMultiplier);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(InfluenceRewardMultiplier));
            }
        }
    }
}
