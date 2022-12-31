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
        public static void GetCraftingPartDifficulty(CraftingPiece craftingPiece, ref int __result)
        {
            try
            {
                if (SettingsManager.SmithingDifficultyPercentage.IsChanged)
                {
                    var factor = SettingsManager.SmithingDifficultyPercentage.Value / 100f;

                    var newValue = (int)Math.Round(factor * __result);

                    __result = newValue;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(SmithingDifficultyPercentage));
            }
        }
    }
}
