using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using BannerlordCheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Sieges
{
    [HarmonyPatch(typeof(DefaultSiegeEventModel), nameof(DefaultSiegeEventModel.GetConstructionProgressPerHour))]
    public static class SiegeBuildingSpeedMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetConstructionProgressPerHour(ref SiegeEngineType type, ref SiegeEvent siegeEvent, ref ISiegeEventSide side, ref float __result)
        {
            try
            {
                if (side.IsPlayerSide()
                    && SettingsManager.SiegeBuildingSpeedMultiplier.IsChanged)
                {
                    __result *= SettingsManager.SiegeBuildingSpeedMultiplier.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(SiegeBuildingSpeedMultiplier));
            }
        }
    }
}
