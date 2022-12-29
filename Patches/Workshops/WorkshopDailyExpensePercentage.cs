using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetDailyExpense))]
    public static class WorkshopDailyExpensePercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetDailyExpense(ref int level, ref int __result)
        {
            try
            {
                if (SettingsManager.WorkshopDailyExpensePercentage.IsChanged)
                {
                    var factor = SettingsManager.WorkshopDailyExpensePercentage.Value / 100f;

                    __result = (int) (__result * factor);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(WorkshopDailyExpensePercentage));
            }
        }
    }
}
