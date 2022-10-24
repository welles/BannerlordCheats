using System;
using System.Linq;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Sieges
{
    [HarmonyPatch(typeof(DefaultSiegeEventModel), nameof(DefaultSiegeEventModel.GetConstructionProgressPerHour))]
    public static class EnemySiegeBuildingSpeedPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetConstructionProgressPerHour(ref SiegeEngineType type, ref SiegeEvent siegeEvent, ref ISiegeEventSide side, ref float result)
        {
            try
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
                    case BattleSideEnum.None:
                    case BattleSideEnum.NumSides:
                    default:
                        return;
                }

                if ((!(siegeEvent.GetSiegeEventSide(otherSide)?.GetInvolvedPartiesForEventType()
                        .Any(x => x.IsPlayerParty()) ?? false))
                    || !(BannerlordCheatsSettings.Instance?.EnemySiegeBuildingSpeedPercentage < 100f)) return;
                var factor = BannerlordCheatsSettings.Instance.EnemySiegeBuildingSpeedPercentage / 100f;

                var newValue = factor * result;

                result = newValue;
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnemySiegeBuildingSpeedPercentage));
            }
        }
    }
}
