using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using BannerlordCheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Sieges
{
    [HarmonyPatch(typeof(DefaultSiegeEventModel), nameof(DefaultSiegeEventModel.GetConstructionProgressPerHour))]
    public static class EnemySiegeBuildingSpeedPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetConstructionProgressPerHour(ref SiegeEngineType type, ref SiegeEvent siegeEvent, ref ISiegeEventSide side, ref float __result)
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
                    default:
                        return;
                }

                if ((siegeEvent.GetSiegeEventSide(otherSide)?.SiegeParties.Any(x => x.IsPlayerParty()) ?? false)
                    && BannerlordCheatsSettings.Instance?.EnemySiegeBuildingSpeedPercentage < 100f)
                {
                    var factor = BannerlordCheatsSettings.Instance.EnemySiegeBuildingSpeedPercentage / 100f;

                    var newValue = factor * __result;

                    __result = newValue;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnemySiegeBuildingSpeedPercentage));
            }
        }
    }
}
