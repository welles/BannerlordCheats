﻿using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;

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
            ref ExplainedNumber result)
        {
            try
            {
                if (town.IsPlayerTown()
                    && BannerlordCheatsSettings.Instance?.ConstructionPowerMultiplier > 1f)
                {
                    result.AddMultiplier(BannerlordCheatsSettings.Instance.ConstructionPowerMultiplier);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ConstructionPowerMultiplier));
            }
        }
    }
}
