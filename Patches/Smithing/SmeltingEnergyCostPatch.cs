using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForSmelting))]
    public static class SmeltingEnergyCostPatch
    {
        [HarmonyPostfix]
        public static void GetEnergyCostForSmelting(ItemObject item, Hero hero, ref int __result)
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
