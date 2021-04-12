using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultDisguiseDetectionModel), nameof(DefaultDisguiseDetectionModel.CalculateDisguiseDetectionProbability))]
    public static class DisguiseAlwaysWorksPatch
    {
        [HarmonyPostfix]
        public static void CalculateDisguiseDetectionProbability(Settlement settlement, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.DisguiseAlwaysWorks, out var disguiseAlwaysWorks)
                && disguiseAlwaysWorks)
            {
                __result = 1;
            }
        }
    }
}
