using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Map
{
    [HarmonyPatch(typeof(DefaultMapVisibilityModel), nameof(DefaultMapVisibilityModel.GetPartySpottingRange))]
    public static class MapVisibilityMultiplier
    {
        [HarmonyPostfix]
        public static void GetPartySpottingRange(ref MobileParty party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.MapVisibilityMultiplier > 1f)
            {
                __result.AddMultiplier(BannerlordCheatsSettings.Instance.MapVisibilityMultiplier);
            }
        }
    }
}
