using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetCraftingPartDifficulty))]
    public static class SmithingDifficultyPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetCraftingPartDifficulty(CraftingPiece craftingPiece, ref int result)
        {
            try
            {
                if (!(BannerlordCheatsSettings.Instance?.SmithingDifficultyPercentage < 100f)) return;
                var factor = BannerlordCheatsSettings.Instance.SmithingDifficultyPercentage / 100f;

                var newValue = (int)Math.Round(factor * result);

                result = newValue;
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(SmithingDifficultyPercentage));
            }
        }
    }
}
