using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), nameof(DefaultPartySpeedCalculatingModel.CalculateFinalSpeed))]
    public static class DefaultPartySpeedCalculatingModelPatch
    {
        [HarmonyPostfix]
        public static void CalculateFinalSpeed(MobileParty mobileParty, float baseSpeed, StatExplainer explanation, ref float __result)
        {
            var multiplier = BannerlordCheatsSettings.Instance.MapSpeedFactor;

            if (mobileParty?.IsMainParty ?? false)
            {
                __result *= multiplier;
            }
        }
    }
}
