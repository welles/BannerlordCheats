using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateInfluenceGain))]
    public static class InfluenceRewardMultiplier
    {
        [HarmonyPostfix]
        public static void CalculateInfluenceGain(
            ref PartyBase party,
            ref float influenceValueOfBattle,
            ref float contributionShare,
            ref ExplainedNumber __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.InfluenceRewardMultiplier > 1f)
            {
                __result.AddMultiplier(BannerlordCheatsSettings.Instance.InfluenceRewardMultiplier);
            }
        }
    }
}
