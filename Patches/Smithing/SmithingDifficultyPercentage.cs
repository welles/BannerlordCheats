using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetCraftingPartDifficulty))]
    public static class SmithingDifficultyPercentage
    {
        [HarmonyPostfix]
        public static void GetCraftingPartDifficulty(CraftingPiece craftingPiece, ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.SmithingDifficultyPercentage, out var smithingDifficultyPercentage))
            {
                var factor = smithingDifficultyPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
