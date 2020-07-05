using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches.Map
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyMemberSizeLimit))]
    public static class BiggerNpcParties
    {
        [HarmonyPostfix]
        public static void GetPartyMemberSizeLimit(PartyBase party, StatExplainer explanation, ref int __result)
        {
            if ((!party?.Leader?.IsPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.BiggerNpcParties)
            {
                __result = 10000;
            }
        }
    }
}
