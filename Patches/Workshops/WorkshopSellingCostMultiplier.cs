using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements.Workshops;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetSellingCost))]
    public static class WorkshopSellingCostMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetSellingCost(ref Workshop workshop, ref int result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.WorkshopSellingCostMultiplier > 1f)
                {
                    result = (int) (result * BannerlordCheatsSettings.Instance.WorkshopSellingCostMultiplier);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(WorkshopSellingCostMultiplier));
            }
        }
    }
}
