using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateInfluenceGain))]
    public static class BattleInfluenceGainPatch
    {
        [HarmonyPostfix]
        public static void CalculateInfluenceGain(PartyBase party, float influenceValueOfBattle, float contributionShare, StatExplainer explanation, ref float __result)
        {
            if (party?.Leader?.IsPlayerCharacter ?? false)
            {
                __result *= BannerlordCheatsSettings.Instance.InfluenceRewardMultiplier;
            }
        }
    }
}
