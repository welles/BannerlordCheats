using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
    public static class PartyPrisonerSizeLimitPatch
    {
        [HarmonyPostfix]
        public static void GetPartyPrisonerSizeLimit(PartyBase party, StatExplainer explanation, ref int __result)
        {
            if (party?.Leader?.IsPlayerCharacter ?? false)
            {
                __result += BannerlordCheatsSettings.Instance.ExtraPartyPrisonerSize;
            }
        }
    }
}
