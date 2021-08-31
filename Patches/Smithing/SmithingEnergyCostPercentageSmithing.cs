using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using BannerlordCheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
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
            if (hero.PartyBelongedTo.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.SmithingEnergyCostPercentage < 100f)
            {
                var factor = BannerlordCheatsSettings.Instance.SmithingEnergyCostPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
