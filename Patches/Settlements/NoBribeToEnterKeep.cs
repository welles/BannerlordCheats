using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultBribeCalculationModel), nameof(DefaultBribeCalculationModel.IsBribeNotNeededToEnterKeep))]
    public static class NoBribeToEnterKeep
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void IsBribeNotNeededToEnterKeep(Settlement settlement, ref bool result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.NoBribeToEnterKeep == true)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoBribeToEnterKeep));
            }
        }
    }
}
