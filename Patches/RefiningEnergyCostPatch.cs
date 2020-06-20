using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetEnergyCostForRefining))]
    public static class RefiningEnergyCostPatch
    {
        [HarmonyPostfix]
        public static void GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero, ref int __result)
        {
            if ((hero?.IsHumanPlayerCharacter ?? false) && BannerlordCheatsSettings.Instance.NoSmithingEnergyCost)
            {
                __result = 0;
            }
        }
    }
}
