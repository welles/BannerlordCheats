using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultCrimeModel), nameof(DefaultCrimeModel.GetCrimeRatingOf))]
    public static class NoCrimeRatingPatch
    {
        [HarmonyPostfix]
        public static void GetCrimeRatingOf(ref CrimeModel.CrimeType crime, ref object[] additionalArgs, ref float __result)
        {
            if (BannerlordCheatsSettings.Instance.NoCrimeRatingForCrimes)
            {
                __result = 0f;
            }
        }
    }
}
