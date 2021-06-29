using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using BannerlordCheats.Extensions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForRefining))]
    public static class SmithingEnergyCostPercentageRefining
    {
        [HarmonyPostfix]
        public static void GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero, ref int __result)
        {
            if (hero.PartyBelongedTo.IsPlayerParty()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.SmithingEnergyCostPercentage, out var smithingEnergyCostPercentage))
            {
                var factor = smithingEnergyCostPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
