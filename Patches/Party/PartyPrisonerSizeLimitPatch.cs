using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyPrisonerSizeLimit))]
    public static class PartyPrisonerSizeLimitPatch
    {
        [HarmonyPostfix]
        public static void GetPartyPrisonerSizeLimit(ref PartyBase party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if ((party?.Leader?.IsPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.ExtraPartyPrisonerSize > 0)
            {
                __result.Add(BannerlordCheatsSettings.Instance.ExtraPartyPrisonerSize);
            }
        }
    }
}
