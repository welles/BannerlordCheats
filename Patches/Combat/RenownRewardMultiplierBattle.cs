using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateRenownGain))]
    public static class RenownRewardMultiplierBattle
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateRenownGain(
            ref PartyBase party,
            ref float renownValueOfBattle,
            ref float contributionShare,
            ref ExplainedNumber __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.RenownRewardMultiplier > 1f)
            {
                __result.AddMultiplier(BannerlordCheatsSettings.Instance.RenownRewardMultiplier);
            }
        }
    }
}
