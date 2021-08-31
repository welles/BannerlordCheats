using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultTournamentModel), nameof(DefaultTournamentModel.GetRenownReward))]
    public static class RenownRewardMultiplierTournament
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRenownReward(Hero winner, Town town, ref int __result)
        {
            if (winner.IsPlayer()
                && BannerlordCheatsSettings.Instance?.RenownRewardMultiplier > 1f)
            {
                __result = (int) Math.Round(__result * BannerlordCheatsSettings.Instance.RenownRewardMultiplier);
            }
        }
    }
}
