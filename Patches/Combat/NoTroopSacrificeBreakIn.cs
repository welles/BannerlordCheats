using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultTroopSacrificeModel), nameof(DefaultTroopSacrificeModel.GetLostTroopCountForBreakingInBesiegedSettlement))]
    public static class NoTroopSacrificeBreakIn
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetLostTroopCountForBreakingInBesiegedSettlement(MobileParty party, SiegeEvent siegeEvent, ref int __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.NoTroopSacrifice == true)
            {
                __result = 0;
            }
        }
    }
}
