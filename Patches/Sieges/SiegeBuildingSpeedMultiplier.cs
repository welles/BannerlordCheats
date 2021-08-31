using BannerlordCheats.Settings;
using HarmonyLib;
using BannerlordCheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
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
            if (side.IsPlayerSide()
                && BannerlordCheatsSettings.Instance?.EnemySiegeBuildingSpeedPercentage > 1f)
            {
                __result *= BannerlordCheatsSettings.Instance.EnemySiegeBuildingSpeedPercentage;
            }
        }
    }
}
