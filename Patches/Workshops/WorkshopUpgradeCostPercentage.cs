using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

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
                if (BannerlordCheatsSettings.Instance?.WorkshopUpgradeCostPercentage < 100f)
                {
                    var factor = BannerlordCheatsSettings.Instance.WorkshopUpgradeCostPercentage / 100f;

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
