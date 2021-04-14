using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Clan
{
    [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetCompanionLimit))]
    public static class CompanionLimitPatch
    {
        [HarmonyPostfix]
        public static void GetCompanionLimit(ref TaleWorlds.CampaignSystem.Clan clan, ref int __result)
        {
            if (clan.IsPlayerClan()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.ExtraCompanionLimit, out var extraCompanionLimit))
            {
                __result += extraCompanionLimit;
            }
        }
    }
}
