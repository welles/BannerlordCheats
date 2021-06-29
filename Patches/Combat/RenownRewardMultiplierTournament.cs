using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultTournamentModel), nameof(DefaultTournamentModel.GetRenownReward))]
    public static class RenownRewardMultiplierTournament
    {
        [HarmonyPostfix]
        public static void GetRenownReward(Hero winner, Town town, ref int __result)
        {
            if (winner.IsPlayer()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.RenownRewardMultiplier, out var renownRewardMultiplier))
            {
                __result = (int) Math.Round(__result * renownRewardMultiplier);
            }
        }
    }
}
