using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.Tournaments.MissionLogics;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(TournamentBehavior), nameof(TournamentBehavior.GetMaximumBet))]
    public static class TournamentMaximumBetMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetMaximumBet(ref int __result)
        {
            try
            {
                if (SettingsManager.TournamentMaximumBetMultiplier.IsChanged)
                {
                    var newValue = (int) Math.Round(__result * SettingsManager.TournamentMaximumBetMultiplier.Value);

                    __result = newValue;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(TournamentMaximumBetMultiplier));
            }
        }
    }
}
