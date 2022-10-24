using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Clan
{
    [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetPartyLimitForTier))]
    public static class ExtraClanPartyLimit
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPartyLimitForTier(TaleWorlds.CampaignSystem.Clan clan, int clanTierToCheck, ref int result)
        {
            try
            {
                if (clan.IsPlayerClan()
                    && BannerlordCheatsSettings.Instance?.ExtraClanPartyLimit > 0)
                {
                    result += BannerlordCheatsSettings.Instance.ExtraClanPartyLimit;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ExtraClanPartyLimit));
            }
        }
    }
}
