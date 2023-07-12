using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements.Workshops;

namespace BannerlordCheats.Patches.Workshops
{
    /*
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetSellingCost))]
    public static class WorkshopSellingCostMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetSellingCost(ref Workshop workshop, ref int __result)
        {
            try
            {
                if (SettingsManager.WorkshopSellingCostMultiplier.IsChanged)
                {
                    __result = (int) (__result * SettingsManager.WorkshopSellingCostMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(WorkshopSellingCostMultiplier));
            }
        }
    }
    */
}
