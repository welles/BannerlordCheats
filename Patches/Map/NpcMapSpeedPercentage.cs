using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Map
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), nameof(DefaultPartySpeedCalculatingModel.CalculateFinalSpeed))]
    public static class NpcMapSpeedPercentage
    {
        [HarmonyPostfix]
        public static void CalculateFinalSpeed(ref MobileParty mobileParty, ref ExplainedNumber finalSpeed, ref ExplainedNumber __result)
        {
            if (!mobileParty.IsPlayerParty()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.NpcMapSpeedPercentage, out var npcMapSpeedPercentage))
            {
                __result.AddPercentage(npcMapSpeedPercentage);
            }
        }
    }
}
