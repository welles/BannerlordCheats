using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Map
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), nameof(DefaultPartySpeedCalculatingModel.CalculateFinalSpeed))]
    public static class SlowDownPartiesOnMap
    {
        [HarmonyPostfix]
        public static void CalculateFinalSpeed(MobileParty mobileParty, float baseSpeed, StatExplainer explanation, ref float __result)
        {
            var percentage = BannerlordCheatsSettings.Instance.NpcMapSpeedPercentage / 100f;

            if (!mobileParty.IsMainParty)
            {
                __result *= percentage;
            }
        }
    }
}
