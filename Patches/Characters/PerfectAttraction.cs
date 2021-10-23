using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

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
            if (BannerlordCheatsSettings.Instance?.PerfectAttraction == true
                && heroOfInterest.IsPlayer())
            {
                __result = 100;
            }
        }
    }
}