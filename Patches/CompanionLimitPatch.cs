using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetCompanionLimitForTier))]
    public static class CompanionLimitPatch
    {
        [HarmonyPostfix]
        public static void GetCompanionLimitForTier(int clanTier, ref int __result)
        {
            __result += BannerlordCheatsSettings.Instance.ExtraCompanionLimit;
        }
    }
}
