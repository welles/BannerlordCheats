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
        public static void GetDailyExpense(ref int level, ref int result)
        {
            try
            {
                if (!(BannerlordCheatsSettings.Instance?.WorkshopDailyExpensePercentage < 100f)) return;
                var factor = BannerlordCheatsSettings.Instance.WorkshopDailyExpensePercentage / 100f;

                result = (int) (result * factor);
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(WorkshopDailyExpensePercentage));
            }
        }
    }
}
