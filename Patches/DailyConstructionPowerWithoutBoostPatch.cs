using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultBuildingConstructionModel), "CalculateDailyConstructionPowerWithoutBoost")]
    public static class DailyConstructionPowerWithoutBoostPatch
    {
        [HarmonyPostfix]
        public static void CalculateDailyConstructionPowerWithoutBoost(Town town, StatExplainer explanation, ref int __result)
        {
            if (town?.Owner?.Leader?.IsPlayerCharacter ?? false)
            {
                __result *= BannerlordCheatsSettings.Instance.ConstructionPowerMultiplier;
            }
        }
    }
}
