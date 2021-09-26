using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultDisguiseDetectionModel), nameof(DefaultDisguiseDetectionModel.CalculateDisguiseDetectionProbability))]
    public static class DisguiseAlwaysWorks
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDisguiseDetectionProbability(Settlement settlement, ref float __result)
        {
            if (BannerlordCheatsSettings.Instance?.DisguiseAlwaysWorks == true)
            {
                __result = 1;
            }
        }
    }
}
