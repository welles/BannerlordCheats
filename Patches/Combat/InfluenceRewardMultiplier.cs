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
            ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.InfluenceRewardMultiplier.IsChanged)
                {
                    __result.AddMultiplier(SettingsManager.InfluenceRewardMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(InfluenceRewardMultiplier));
            }
        }
    }
}
