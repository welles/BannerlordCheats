using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetBuyingCostForPlayer))]
    public static class WorkshopBuyingCostPercentage
    {
        [HarmonyPostfix]
        public static void GetBuyingCostForPlayer(ref Workshop workshop, ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.WorkshopBuyingCostPercentage, out var workshopBuyingCostPercentage))
            {
                var factor = workshopBuyingCostPercentage / 100f;

                __result = (int) (__result * factor);
            }
        }
    }
}
