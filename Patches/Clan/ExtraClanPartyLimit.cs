using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Clan
{
    [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetPartyLimitForTier))]
    public static class ExtraClanPartyLimit
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPartyLimitForTier(TaleWorlds.CampaignSystem.Clan clan, int clanTierToCheck, ref int __result)
        {
            if (clan.IsPlayerClan()
                && BannerlordCheatsSettings.Instance?.ExtraClanPartyLimit > 0)
            {
                __result += BannerlordCheatsSettings.Instance.ExtraClanPartyLimit;
            }
        }
    }
}
