using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements.Workshops;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetBuyingCostForPlayer))]
    public static class WorkshopBuyingCostPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetBuyingCostForPlayer(ref Workshop workshop, ref int __result)
        {
            try
            {
                if (SettingsManager.WorkshopBuyingCostPercentage.IsChanged)
                {
                    var factor = SettingsManager.WorkshopBuyingCostPercentage.Value / 100f;

                    __result = (int) (__result * factor);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(WorkshopBuyingCostPercentage));
            }
        }
    }
}
