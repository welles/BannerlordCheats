using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Map
{
    [HarmonyPatch(typeof(DefaultMapVisibilityModel), nameof(DefaultMapVisibilityModel.GetPartySpottingRange))]
    public static class MapVisibilityMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPartySpottingRange(ref MobileParty party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.MapVisibilityMultiplier.IsChanged)
                {
                    __result.AddMultiplier(SettingsManager.MapVisibilityMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(MapVisibilityMultiplier));
            }
        }
    }
}
