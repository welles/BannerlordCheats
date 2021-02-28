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
            if ((winner?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.RenownRewardMultiplier > 1)
            {
                __result *= BannerlordCheatsSettings.Instance.RenownRewardMultiplier;
            }
        }
    }
}
