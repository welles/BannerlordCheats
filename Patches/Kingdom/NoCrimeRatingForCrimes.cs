using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultCrimeModel), nameof(DefaultCrimeModel.GetCrimeRatingOf))]
    public static class NoCrimeRatingForCrimes
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetCrimeRatingOf(ref CrimeModel.CrimeType crime, ref object[] additionalArgs, ref float __result)
        {
            if (BannerlordCheatsSettings.Instance?.NoCrimeRatingForCrimes == true)
            {
                __result = 0f;
            }
        }
    }
}
