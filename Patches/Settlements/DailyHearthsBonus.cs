using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Village), nameof(Village.HearthChange), MethodType.Getter)]
    public static class DailyHearthsBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void HearthChange(ref Village instance, ref float result)
        {
            try
            {
                if (instance.IsPlayerVillage()
                    && BannerlordCheatsSettings.Instance?.DailyHearthsBonus > 0)
                {
                    result += BannerlordCheatsSettings.Instance.DailyHearthsBonus;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DailyHearthsBonus));
            }
        }
    }
}
