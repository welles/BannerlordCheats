using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(BarterManager), nameof(BarterManager.IsOfferAcceptable), new[] { typeof(BarterData), typeof(Hero), typeof(PartyBase) })]
    public static class BarterOfferAlwaysAccepted
    {
        [HarmonyPostfix]
        public static void IsOfferAcceptable(BarterData args, Hero hero, PartyBase party, ref BarterManager __instance, ref bool __result)
        {
            if (BannerlordCheatsSettings.Instance.BarterOfferAlwaysAccepted)
            {
                __result = true;
            }
        }
    }
}
