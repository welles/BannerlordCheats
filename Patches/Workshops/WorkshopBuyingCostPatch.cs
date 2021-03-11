using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetBuyingCostForPlayer))]
    public static class WorkshopBuyingCostPatch
    {
        [HarmonyPostfix]
        public static void GetBuyingCostForPlayer(ref Workshop workshop, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance.WorkshopBuyingCostPercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.WorkshopBuyingCostPercentage / 100f;

                __result = (int) (__result * factor);
            }
        }
    }
}
