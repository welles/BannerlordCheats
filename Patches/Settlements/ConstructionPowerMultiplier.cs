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
            ref ExplainedNumber __result)
        {
            try
            {
                if (town.IsPlayerTown()
                    && SettingsManager.ConstructionPowerMultiplier.IsChanged)
                {
                    __result.AddMultiplier(SettingsManager.ConstructionPowerMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ConstructionPowerMultiplier));
            }
        }
    }
}
