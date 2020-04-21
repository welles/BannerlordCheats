using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), "CalculateRenownGain")]
    public static class BattleRenownGainPatch
    {
        [HarmonyPostfix]
        public static void CalculateRenownGain(PartyBase party, float renownValueOfBattle, float contributionShare, StatExplainer explanation, ref float __result)
        {
            if (party?.Leader?.IsPlayerCharacter ?? false)
            {
                __result *= BannerlordCheatsSettings.Instance.RenownRewardMultiplier;
            }
        }
    }
}
