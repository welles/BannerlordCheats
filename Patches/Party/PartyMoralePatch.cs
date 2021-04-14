using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartyMoraleModel), nameof(DefaultPartyMoraleModel.GetEffectivePartyMorale))]
    public static class PartyMoralePatch
    {
        [HarmonyPostfix]
        public static void GetEffectivePartyMorale(ref MobileParty mobileParty, ref bool includeDescription, ref ExplainedNumber __result)
        {
            if (mobileParty.IsPlayerParty()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.ExtraPartyMorale, out var extraPartyMorale))
            {
                __result.Add(extraPartyMorale);
            }
        }
    }
}
