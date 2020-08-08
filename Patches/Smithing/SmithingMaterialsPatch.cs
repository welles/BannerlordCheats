using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetSmithingCostsForWeaponDesign))]
    public static class SmithingMaterialsPatch
    {
        [HarmonyPostfix]
        public static void GetSmithingCostsForWeaponDesign(WeaponDesign weaponDesign, ref int[] __result)
        {
            if (BannerlordCheatsSettings.Instance.SmithingCostPercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.SmithingCostPercentage / 100f;

                for (var i = 0; i < __result.Length; i++)
                {
                    var newValue = (int)Math.Round(factor * __result[i]);

                    __result[i] = newValue;
                }
            }
        }
    }
}
