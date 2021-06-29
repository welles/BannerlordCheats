using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetSmithingCostsForWeaponDesign))]
    public static class SmithingCostPercentage
    {
        [HarmonyPostfix]
        public static void GetSmithingCostsForWeaponDesign(WeaponDesign weaponDesign, ref int[] __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.SmithingCostPercentage, out var smithingCostPercentage))
            {
                var factor = smithingCostPercentage / 100f;

                for (var i = 0; i < __result.Length; i++)
                {
                    var newValue = (int)Math.Round(factor * __result[i]);

                    __result[i] = newValue;
                }
            }
        }
    }
}
