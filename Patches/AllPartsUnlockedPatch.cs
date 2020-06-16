using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(CraftingCampaignBehavior), "IsOpened")]
    public static class AllPartsUnlockedPatch
    {
        [HarmonyPostfix]
        public static void IsOpened(CraftingPiece craftingPiece, ref bool __result)
        {
            if (BannerlordCheatsSettings.Instance.UnlockAllParts)
            {
                __result = true;
            }
        }
    }
}
