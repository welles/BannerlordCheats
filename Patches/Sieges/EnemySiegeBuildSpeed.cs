using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using System.Linq;
using BannerlordCheats.Extensions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Sieges
{
    [HarmonyPatch(typeof(DefaultSiegeEventModel), nameof(DefaultSiegeEventModel.GetConstructionProgressPerHour))]
    public static class EnemySiegeBuildSpeed
    {
        [HarmonyPostfix]
        public static void GetConstructionProgressPerHour(ref SiegeEngineType type, ref SiegeEvent siegeEvent, ref ISiegeEventSide side, ref float __result)
        {
            BattleSideEnum otherSide;
            switch (side.BattleSide)
            {
                case BattleSideEnum.Attacker:
                    otherSide = BattleSideEnum.Defender;
                    break;
                case BattleSideEnum.Defender:
                    otherSide = BattleSideEnum.Attacker;
                    break;
                default:
                    return;
            }

            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.EnemySiegeBuildingSpeedPercentage, out var enemySiegeBuildingSpeedPercentage)
                && (siegeEvent.GetSiegeEventSide(otherSide)?.SiegeParties.Any(x => x.IsPlayerParty()) ?? false))
            {
                var factor = enemySiegeBuildingSpeedPercentage / 100f;

                var newValue = factor * __result;

                __result = newValue;
            }
        }
    }
}
