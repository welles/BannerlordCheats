using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBanditDensityModel), nameof(DefaultBanditDensityModel.GetPlayerMaximumTroopCountForHideoutMission))]
    public static class BanditHideoutTroopLimitPatch
    {
        [HarmonyPostfix]
        public static void GetPlayerMaximumTroopCountForHideoutMission(ref MobileParty party, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance.BanditHideoutTroopLimit > 0)
            {
                __result += BannerlordCheatsSettings.Instance.BanditHideoutTroopLimit;
            }
        }
    }
}
