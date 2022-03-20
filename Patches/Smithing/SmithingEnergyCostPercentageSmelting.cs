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
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForSmelting))]
    public static class SmithingEnergyCostPercentageSmelting
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetEnergyCostForSmelting(ItemObject item, Hero hero, ref int __result)
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
                SubModule.LogError(e, typeof(SmithingEnergyCostPercentageSmelting));
            }
        }
    }
}
