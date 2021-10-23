﻿using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultBribeCalculationModel), nameof(DefaultBribeCalculationModel.IsBribeNotNeededToEnterKeep))]
    public static class NoBribeToEnterKeep
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void IsBribeNotNeededToEnterKeep(Settlement settlement, ref bool __result)
        {
            if (BannerlordCheatsSettings.Instance?.NoBribeToEnterKeep == true)
            {
                __result = true;
            }
        }
    }
}