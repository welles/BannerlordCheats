using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultCrimeModel), nameof(DefaultCrimeModel.GetCrimeRatingOf))]
    public static class NoCrimeRatingForCrimes
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetCrimeRatingOf(ref CrimeModel.CrimeType crime, ref object[] additionalArgs, ref float __result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.NoCrimeRatingForCrimes == true)
                {
                    __result = 0f;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoCrimeRatingForCrimes));
            }
        }
    }
}
