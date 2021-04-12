using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using BannerlordCheats.Extensions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForSmelting))]
    public static class SmeltingEnergyCostPatch
    {
        [HarmonyPostfix]
        public static void GetEnergyCostForSmelting(ItemObject item, Hero hero, ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.SmithingEnergyCostPercentage, out var smithingEnergyCostPercentage)
                && hero.PartyBelongedTo.IsPlayerParty())
            {
                var factor = smithingEnergyCostPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
