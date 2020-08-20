using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultBanditDensityModel), nameof(DefaultBanditDensityModel.PlayerMaximumTroopCountForHideoutMission), MethodType.Getter)]
    public static class BanditHideoutTroopLimitPatch
    {
        [HarmonyPostfix]
        public static void PlayerMaximumTroopCountForHideoutMission(ref int __result)
        {
            __result += BannerlordCheatsSettings.Instance.BanditHideoutTroopLimit;
        }
    }
}
