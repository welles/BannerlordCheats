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
            if (BannerlordCheatsSettings.Instance.WorkshopDailyExpensePercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.WorkshopDailyExpensePercentage / 100f;

                __result = (int) (__result * factor);
            }
        }
    }
}
