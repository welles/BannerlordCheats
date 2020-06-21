using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultSiegeEventModel), nameof(DefaultSiegeEventModel.GetConstructionProgressPerHour))]
    public static class DefaultSiegeEventModelPatch
    {
        [HarmonyPostfix]
        public static void GetConstructionProgressPerHour(SiegeEngineType type, SiegeEvent siegeEvent, ISiegeEventSide side, StatExplainer explanation, ref float __result)
        {
            if (side?.SiegeParties?.Any(x => x.Leader?.IsPlayerCharacter ?? false) ?? false)
            {
                __result *= BannerlordCheatsSettings.Instance.SiegeBuildingSpeedMultiplier;
            }
        }
    }
}
