using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultCrimeModel), nameof(DefaultCrimeModel.GetCrimeRatingOf))]
    public static class NoCrimeRatingForCrimes
    {
        [HarmonyPostfix]
        public static void GetCrimeRatingOf(ref CrimeModel.CrimeType crime, ref object[] additionalArgs, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.NoCrimeRatingForCrimes, out var noCrimeRatingForCrimes)
                && noCrimeRatingForCrimes)
            {
                __result = 0f;
            }
        }
    }
}
