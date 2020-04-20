using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "CalculateFinalSpeed")]
    public class DefaultPartySpeedCalculatingModelPatch
    {
        [HarmonyPostfix]
        public static void CalculateFinalSpeed(MobileParty mobileParty, float baseSpeed, StatExplainer explanation, ref float __result)
        {
            if (mobileParty?.IsMainParty ?? false)
            {
                __result = __result * 4;
            }
        }
    }
}
