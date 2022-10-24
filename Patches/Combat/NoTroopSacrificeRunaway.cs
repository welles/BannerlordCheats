using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultTroopSacrificeModel), nameof(DefaultTroopSacrificeModel.GetNumberOfTroopsSacrificedForTryingToGetAway))]
    public static class NoTroopSacrificeRunaway
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetNumberOfTroopsSacrificedForTryingToGetAway(BattleSideEnum battleSide, MapEvent mapEvent, ref int result)
        {
            try
            {
                if (mapEvent.IsPlayerMapEvent
                    && battleSide == mapEvent.PlayerSide
                    && BannerlordCheatsSettings.Instance?.NoTroopSacrifice == true)
                {
                    result = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoTroopSacrificeRunaway));
            }
        }
    }
}
