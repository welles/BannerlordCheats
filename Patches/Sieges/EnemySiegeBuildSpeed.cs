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

            if ((siegeEvent.GetSiegeEventSide(otherSide)?.SiegeParties.Any(x => x.IsPlayerParty()) ?? false)
                && BannerlordCheatsSettings.Instance.EnemySiegeBuildingSpeedPercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.EnemySiegeBuildingSpeedPercentage / 100f;

                var newValue = factor * __result;

                __result = newValue;
            }
        }
    }
}
