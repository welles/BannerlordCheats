using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(RebellionsCampaignBehavior), "CheckRebellionEvent")]
    public static class RebellionChancePercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CheckRebellionEvent(
            ref Settlement settlement,
            ref bool __result)
        {
            try
            {
                if (settlement.IsPlayerSettlement()
                    && SettingsManager.SettlementsNeverRebel.IsChanged)
                {
                    __result = false;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(RebellionChancePercentage));
            }
        }
    }
}
