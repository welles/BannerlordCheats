using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultBuildingConstructionModel), nameof(DefaultBuildingConstructionModel.CalculateDailyConstructionPower))]
    public static class ConstructionPowerMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDailyConstructionPower(
            ref Town town,
            ref bool includeDescriptions,
            ref ExplainedNumber __result)
        {
            try
            {
                if (town.IsPlayerTown()
                    && BannerlordCheatsSettings.Instance?.ConstructionPowerMultiplier > 1f)
                {
                    __result.AddMultiplier(BannerlordCheatsSettings.Instance.ConstructionPowerMultiplier);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ConstructionPowerMultiplier));
            }
        }
    }
}
