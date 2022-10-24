using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Village), nameof(Village.MilitiaChange), MethodType.Getter)]
    public static class DailyMilitiaBonusVillage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void MilitiaChange(ref Village instance, ref float result)
        {
            try
            {
                if (instance.IsPlayerVillage()
                    && BannerlordCheatsSettings.Instance?.DailyMilitiaBonus > 0)
                {
                    result += BannerlordCheatsSettings.Instance.DailyMilitiaBonus;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyMilitiaBonusVillage));
            }
        }
    }
}
