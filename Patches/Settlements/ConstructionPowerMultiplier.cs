using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultBuildingConstructionModel), nameof(DefaultBuildingConstructionModel.CalculateDailyConstructionPower))]
    public static class ConstructionPowerMultiplier
    {
        [HarmonyPostfix]
        public static void CalculateDailyConstructionPower(
            ref Town town,
            ref bool includeDescriptions,
            ref ExplainedNumber __result)
        {
            if (town.IsPlayerTown()
                && BannerlordCheatsSettings.Instance?.ConstructionPowerMultiplier > 1f)
            {
                __result.AddMultiplier(BannerlordCheatsSettings.Instance.ConstructionPowerMultiplier);
            }
        }
    }
}
