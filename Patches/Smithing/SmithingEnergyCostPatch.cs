using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForSmithing))]
    public static class SmithingEnergyCostPatch
    {
        [HarmonyPostfix]
        public static void GetEnergyCostForSmithing(ItemObject item, Hero hero, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance.SmithingEnergyCostPercentage < 100
                && (hero.PartyBelongedTo?.IsMainParty ?? false))
            {
                var factor = BannerlordCheatsSettings.Instance.SmithingEnergyCostPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
