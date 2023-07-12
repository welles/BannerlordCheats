using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements.Workshops;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(Workshop), nameof(Workshop.Expense), MethodType.Getter)]
    public static class WorkshopDailyExpensePercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void Expense(ref Workshop __instance, ref int __result)
        {
            try
            {
                if (SettingsManager.WorkshopDailyExpensePercentage.IsChanged && __instance.Owner.IsPlayer())
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
