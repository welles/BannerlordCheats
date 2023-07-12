﻿using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using BannerlordCheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForSmithing))]
    public static class SmithingEnergyCostPercentageSmithing
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetEnergyCostForSmithing(ItemObject item, Hero hero, ref int __result)
        {
            try
            {
                if (hero.PartyBelongedTo.IsPlayerParty()
                    && SettingsManager.SmithingEnergyCostPercentage.IsChanged)
                {
                    var factor = SettingsManager.SmithingEnergyCostPercentage.Value / 100f;

                    var newValue = (int)Math.Round(factor * __result);

                    __result = newValue;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(SmithingEnergyCostPercentageSmithing));
            }
        }
    }
}
