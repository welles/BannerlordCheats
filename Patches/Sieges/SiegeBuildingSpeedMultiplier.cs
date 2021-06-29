using BannerlordCheats.Settings;
using HarmonyLib;
using BannerlordCheats.Extensions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Sieges
{
    [HarmonyPatch(typeof(DefaultSiegeEventModel), nameof(DefaultSiegeEventModel.GetConstructionProgressPerHour))]
    public static class SiegeBuildingSpeedMultiplier
    {
        [HarmonyPostfix]
        public static void GetConstructionProgressPerHour(ref SiegeEngineType type, ref SiegeEvent siegeEvent, ref ISiegeEventSide side, ref float __result)
        {
            if (side.IsPlayerSide()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.SiegeBuildingSpeedMultiplier, out var siegeBuildingSpeedMultiplier))
            {
                __result *= siegeBuildingSpeedMultiplier;
            }
        }
    }
}
