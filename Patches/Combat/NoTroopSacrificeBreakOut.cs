using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultTroopSacrificeModel), nameof(DefaultTroopSacrificeModel.GetLostTroopCountForBreakingOutOfBesiegedSettlement))]
    public static class NoTroopSacrificeBreakOut
    {
        [HarmonyPostfix]
        public static void GetLostTroopCountForBreakingOutOfBesiegedSettlement(MobileParty party, SiegeEvent siegeEvent, ref int __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.NoTroopSacrifice == true)
            {
                __result = 0;
            }
        }
    }
}
