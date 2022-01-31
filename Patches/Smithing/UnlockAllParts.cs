using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(CraftingCampaignBehavior), nameof(CraftingCampaignBehavior.IsOpened))]
    public static class UnlockAllParts
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void IsOpened(CraftingPiece craftingPiece, ref bool __result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.UnlockAllParts == true)
                {
                    __result = true;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(UnlockAllParts));
            }
        }
    }
}
