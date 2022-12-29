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
    [HarmonyPatch(typeof(DefaultTroopSacrificeModel), nameof(DefaultTroopSacrificeModel.GetLostTroopCountForBreakingOutOfBesiegedSettlement))]
    public static class NoTroopSacrificeBreakOut
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetLostTroopCountForBreakingOutOfBesiegedSettlement(MobileParty party, SiegeEvent siegeEvent, ref int __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.NoTroopSacrifice.IsChanged)
                {
                    __result = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoTroopSacrificeBreakOut));
            }
        }
    }
}
