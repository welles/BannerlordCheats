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
        public static void GetUpgradeCost(ref int currentLevel, ref int result)
        {
            try
            {
                if (!(BannerlordCheatsSettings.Instance?.WorkshopUpgradeCostPercentage < 100f)) return;
                var factor = BannerlordCheatsSettings.Instance.WorkshopUpgradeCostPercentage / 100f;

                result = (int) (result * factor);
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(WorkshopUpgradeCostPercentage));
            }
        }
    }
}
