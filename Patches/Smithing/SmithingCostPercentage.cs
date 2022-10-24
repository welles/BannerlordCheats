using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetSmithingCostsForWeaponDesign))]
    public static class SmithingCostPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetSmithingCostsForWeaponDesign(WeaponDesign weaponDesign, ref int[] result)
        {
            try
            {
                if (!(BannerlordCheatsSettings.Instance?.SmithingCostPercentage < 100f)) return;
                var factor = BannerlordCheatsSettings.Instance.SmithingCostPercentage / 100f;

                for (var i = 0; i < result.Length; i++)
                {
                    var newValue = (int)Math.Round(factor * result[i]);

                    result[i] = newValue;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(SmithingCostPercentage));
            }
        }
    }
}
