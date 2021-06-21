using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateInfluenceGain))]
    public static class BattleInfluenceGainPatch
    {
        [HarmonyPostfix]
        public static void CalculateInfluenceGain(
            ref PartyBase party,
            ref float influenceValueOfBattle,
            ref float contributionShare,
            ref ExplainedNumber __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.InfluenceRewardMultiplier, out var influenceRewardMultiplier))
            {
                __result.AddMultiplier(influenceRewardMultiplier);
            }
        }
    }
}
