using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyMemberSizeLimit))]
    public static class PartyMemberSizeLimitPatch
    {
        [HarmonyPostfix]
        public static void GetPartyMemberSizeLimit(ref PartyBase party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if (party?.Leader?.IsPlayerCharacter ?? false)
            {
                __result.Add(BannerlordCheatsSettings.Instance.ExtraPartyMemberSize);
            }
        }
    }
}
