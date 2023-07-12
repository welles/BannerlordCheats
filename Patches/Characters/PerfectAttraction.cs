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
            ref int __result)
        {
            try
            {
                if (SettingsManager.PerfectAttraction.IsChanged
                    && heroOfInterest.IsPlayer())
                {
                    __result = 100;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PerfectAttraction));
            }
        }
    }
}
