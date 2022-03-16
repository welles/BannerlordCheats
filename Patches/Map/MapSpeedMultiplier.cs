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
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), nameof(DefaultPartySpeedCalculatingModel.CalculateFinalSpeed))]
    public static class MapSpeedMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateFinalSpeed(ref MobileParty mobileParty, ref ExplainedNumber finalSpeed, ref ExplainedNumber __result)
        {
            try
            {
                if (mobileParty.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.MapSpeedMultiplier > 1f)
                {
                    __result.AddMultiplier(BannerlordCheatsSettings.Instance.MapSpeedMultiplier);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(MapSpeedMultiplier));
            }
        }
    }
}
