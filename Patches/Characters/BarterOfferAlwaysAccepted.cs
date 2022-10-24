using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.BarterSystem;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(BarterManager), nameof(BarterManager.IsOfferAcceptable), new[] { typeof(BarterData), typeof(Hero), typeof(PartyBase) })]
    public static class BarterOfferAlwaysAccepted
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void IsOfferAcceptable(BarterData args, Hero hero, PartyBase party, ref BarterManager instance, ref bool result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.BarterOfferAlwaysAccepted == true)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(BarterOfferAlwaysAccepted));
            }
        }
    }
}
