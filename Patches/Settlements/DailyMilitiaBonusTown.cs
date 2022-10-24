using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.MilitiaChange), MethodType.Getter)]
    public static class DailyMilitiaBonusTown
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void MilitiaChange(ref Town instance, ref float result)
        {
            try
            {
                if (instance.IsPlayerTown()
                    && BannerlordCheatsSettings.Instance?.DailyMilitiaBonus > 0)
                {
                    result += BannerlordCheatsSettings.Instance.DailyMilitiaBonus;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyMilitiaBonusTown));
            }
        }
    }
}
