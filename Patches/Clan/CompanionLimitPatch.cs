using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetCompanionLimit))]
    public static class CompanionLimitPatch
    {
        [HarmonyPostfix]
        public static void GetCompanionLimit(ref Clan clan, ref int __result)
        {
            if (clan?.Leader?.IsHumanPlayerCharacter ?? false)
            {
                __result += BannerlordCheatsSettings.Instance.ExtraCompanionLimit;
            }
        }
    }
}
