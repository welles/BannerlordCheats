using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), "DoesPartyConsumeFood")]
    public static class NoFoodConsumptionPatch
    {
        [HarmonyPostfix]
        public static void DoesPartyConsumeFood(MobileParty mobileParty, ref bool __result)
        {
            if ((mobileParty?.IsMainParty ?? false)
                && BannerlordCheatsSettings.Instance.NoFoodConsumption)
            {
                __result = false;
            }
        }
    }
}
