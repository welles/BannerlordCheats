using BannerlordCheats.Settings;
using HarmonyLib;
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
            if (BannerlordCheatsSettings.Instance.NoSmithingCost)
            {
                for (var i = 0; i < __result.Length; i++)
                {
                    __result[i] = 0;
                }
            }
        }
    }
}
