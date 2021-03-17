using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Clan
{
    [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetPartyLimitForTier))]
    public static class ClanPartyLimitPatch
    {
        [HarmonyPostfix]
        public static void GetPartyLimitForTier(TaleWorlds.CampaignSystem.Clan clan, int clanTierToCheck, ref int __result)
        {
            if ((clan?.Leader?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.ExtraClanPartyLimit > 0)
            {
                __result += BannerlordCheatsSettings.Instance.ExtraClanPartyLimit;
            }
        }
    }
}
