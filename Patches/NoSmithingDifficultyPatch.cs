using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultSmithingModel), "GetCraftingPartDifficulty")]
    public static class NoSmithingDifficultyPatch
    {
        [HarmonyPostfix]
        public static void GetCraftingPartDifficulty(CraftingPiece craftingPiece, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance.NoSmithingDifficulty)
            {
                __result = 0;
            }
        }
    }
}