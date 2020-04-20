using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
    public static class PartyMemberSizeLimitPatch
    {
        [HarmonyPostfix]
        public static void GetPartyMemberSizeLimit(PartyBase party, StatExplainer explanation, ref int __result)
        {
            if (party?.Leader?.IsPlayerCharacter ?? false)
            {
                __result += BannerlordCheatsSettings.Instance.ExtraPartyMemberSize;
            }
        }
    }
}
