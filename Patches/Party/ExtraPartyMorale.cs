using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartyMoraleModel), nameof(DefaultPartyMoraleModel.GetEffectivePartyMorale))]
    public static class ExtraPartyMorale
    {
        [HarmonyPostfix]
        public static void GetEffectivePartyMorale(ref MobileParty mobileParty, ref bool includeDescription, ref ExplainedNumber __result)
        {
            if (mobileParty.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.ExtraPartyMorale > 0)
            {
                __result.Add(BannerlordCheatsSettings.Instance.ExtraPartyMorale);
            }
        }
    }
}
