using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultRomanceModel), nameof(DefaultRomanceModel.GetAttractionValuePercentage))]
    public static class PerfectAttraction
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAttractionValuePercentage(
            ref Hero potentiallyInterestedCharacter,
            ref Hero heroOfInterest,
            ref int result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.PerfectAttraction == true
                    && heroOfInterest.IsPlayer())
                {
                    result = 100;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PerfectAttraction));
            }
        }
    }
}
