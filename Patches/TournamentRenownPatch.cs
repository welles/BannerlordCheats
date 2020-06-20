using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultTournamentModel), nameof(DefaultTournamentModel.GetRenownReward))]
    public static class TournamentRenownPatch
    {
        [HarmonyPostfix]
        public static void GetRenownReward(Hero winner, Town town, ref int __result)
        {
            if (winner?.IsHumanPlayerCharacter ?? false)
            {
                var multiplier = (int)BannerlordCheatsSettings.Instance.RenownRewardMultiplier;

                __result *= multiplier;
            }
        }
    }
}
