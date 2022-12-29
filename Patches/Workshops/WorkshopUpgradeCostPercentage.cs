using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetUpgradeCost))]
    public static class WorkshopUpgradeCostPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetUpgradeCost(ref int currentLevel, ref int __result)
        {
            try
            {
                if (SettingsManager.WorkshopUpgradeCostPercentage.IsChanged)
                {
                    var factor = SettingsManager.WorkshopUpgradeCostPercentage.Value / 100f;

                    __result = (int) (__result * factor);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(WorkshopUpgradeCostPercentage));
            }
        }
    }
}
