using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Sieges
{
    [HarmonyPatch(typeof(DefaultSiegeEventModel), nameof(DefaultSiegeEventModel.GetConstructionProgressPerHour))]
    public static class EnemySiegeBuildSpeed
    {
        [HarmonyPostfix]
        public static void GetConstructionProgressPerHour(SiegeEngineType type, SiegeEvent siegeEvent, ISiegeEventSide side, StatExplainer explanation, ref float __result)
        {
            if ((siegeEvent?.BesiegerCamp?.SiegeParties.Any(x => x.Leader?.IsPlayerCharacter ?? false) ?? false)
                && (!side?.SiegeParties.Any(x => x.Leader?.IsPlayerCharacter ?? false) ?? false)
                && BannerlordCheatsSettings.Instance.NoEnemySiegeBuilding)
            {
                __result = 0;
            }
        }
    }
}
