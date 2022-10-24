using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Siege;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultTroopSacrificeModel), nameof(DefaultTroopSacrificeModel.GetLostTroopCountForBreakingInBesiegedSettlement))]
    public static class NoTroopSacrificeBreakIn
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetLostTroopCountForBreakingInBesiegedSettlement(MobileParty party, SiegeEvent siegeEvent, ref int result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.NoTroopSacrifice == true)
                {
                    result = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoTroopSacrificeBreakIn));
            }
        }
    }
}
