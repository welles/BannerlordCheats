using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForRefining))]
    public static class RefiningEnergyCostPatch
    {
        [HarmonyPostfix]
        public static void GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero, ref int __result)
        {
            if ((hero?.IsHumanPlayerCharacter ?? false) && BannerlordCheatsSettings.Instance.SmithingEnergyCostPercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.SmithingEnergyCostPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
