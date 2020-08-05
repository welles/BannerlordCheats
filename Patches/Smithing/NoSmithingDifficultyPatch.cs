using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetCraftingPartDifficulty))]
    public static class NoSmithingDifficultyPatch
    {
        [HarmonyPostfix]
        public static void GetCraftingPartDifficulty(CraftingPiece craftingPiece, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance.SmithingDifficultyPercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.SmithingDifficultyPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}