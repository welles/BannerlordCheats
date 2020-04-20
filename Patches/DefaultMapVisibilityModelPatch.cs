using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultMapVisibilityModel), "GetPartySpottingRange")]
    public static class DefaultMapVisibilityModelPatch
    {
        [HarmonyPostfix]
        public static void GetPartySpottingRange(MobileParty party, StatExplainer explainer, ref float __result)
        {
            if (party?.IsMainParty ?? false)
            {
                __result *= BannerlordCheatsSettings.Instance.MapVisibilityFactor;
            }
        }
    }
}
