using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateRenownGain))]
    public static class BattleRenownGainPatch
    {
        [HarmonyPostfix]
        public static void CalculateRenownGain(ref PartyBase party, ref float renownValueOfBattle, ref float contributionShare, ref ExplainedNumber result, ref float __result)
        {
            if ((party?.Leader?.IsPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.RenownRewardMultiplier > 1)
            {
                __result *= BannerlordCheatsSettings.Instance.RenownRewardMultiplier;
            }
        }
    }
}
