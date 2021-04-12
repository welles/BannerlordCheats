using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetDailyExpense))]
    public static class WorkshopDailyExpensePatch
    {
        [HarmonyPostfix]
        public static void GetDailyExpense(ref int level, ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.WorkshopDailyExpensePercentage, out var workshopDailyExpensePercentage))
            {
                var factor = workshopDailyExpensePercentage / 100f;

                __result = (int) (__result * factor);
            }
        }
    }
}
