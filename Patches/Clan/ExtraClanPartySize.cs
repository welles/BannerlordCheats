using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches.Clan
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyMemberSizeLimit))]
    public static class ExtraClanPartySize
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPartyMemberSizeLimit(ref PartyBase party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if (party.IsPlayerClan()
                && !party.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.ExtraClanPartySize > 0)
            {
                __result.Add(BannerlordCheatsSettings.Instance.ExtraClanPartySize);
            }
        }
    }
}
