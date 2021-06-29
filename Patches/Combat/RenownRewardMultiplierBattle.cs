using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateRenownGain))]
    public static class RenownRewardMultiplierBattle
    {
        [HarmonyPostfix]
        public static void CalculateRenownGain(
            ref PartyBase party,
            ref float renownValueOfBattle,
            ref float contributionShare,
            ref ExplainedNumber __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.RenownRewardMultiplier, out var renownRewardMultiplier))
            {
                __result.AddMultiplier(renownRewardMultiplier);
            }
        }
    }
}
