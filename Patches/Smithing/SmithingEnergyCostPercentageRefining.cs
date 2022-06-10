using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using BannerlordCheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForRefining))]
    public static class SmithingEnergyCostPercentageRefining
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero, ref int __result)
        {
            try
            {
                if (hero.PartyBelongedTo.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.SmithingEnergyCostPercentage < 100f)
                {
                    var factor = BannerlordCheatsSettings.Instance.SmithingEnergyCostPercentage / 100f;

                    var newValue = (int)Math.Round(factor * __result);

                    __result = newValue;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(SmithingEnergyCostPercentageRefining));
            }
        }
    }
}
