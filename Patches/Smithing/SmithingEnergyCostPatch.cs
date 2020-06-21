using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForSmithing))]
    public static class SmithingEnergyCostPatch
    {
        [HarmonyPostfix]
        public static void GetEnergyCostForSmithing(ItemObject item, Hero hero, ref int __result)
        {
            if ((hero?.IsHumanPlayerCharacter ?? false) && BannerlordCheatsSettings.Instance.NoSmithingEnergyCost)
            {
                __result = 0;
            }
        }
    }
}
