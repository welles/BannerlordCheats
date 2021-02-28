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
        public static void CalculateFinalSpeed(ref MobileParty mobileParty, ref ExplainedNumber finalSpeed, ref ExplainedNumber __result)
        {
            if (BannerlordCheatsSettings.Instance.NpcMapSpeedPercentage < 100)
            {
                var percentage = BannerlordCheatsSettings.Instance.NpcMapSpeedPercentage / 100f;

                if (!mobileParty.IsMainParty)
                {
                    __result.AddFactor(percentage);
                }
            }
        }
    }
}
