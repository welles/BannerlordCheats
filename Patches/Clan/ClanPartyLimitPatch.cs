using BannerlordCheats.Extensions;
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
            if (clan.IsPlayerClan()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.ExtraClanPartyLimit, out var extraClanPartyLimit))
            {
                __result += extraClanPartyLimit;
            }
        }
    }
}
