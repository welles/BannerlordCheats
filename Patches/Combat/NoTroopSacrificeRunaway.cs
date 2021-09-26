using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultTroopSacrificeModel), nameof(DefaultTroopSacrificeModel.GetNumberOfTroopsSacrificedForTryingToGetAway))]
    public static class NoTroopSacrificeRunaway
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetNumberOfTroopsSacrificedForTryingToGetAway(BattleSideEnum battleSide, MapEvent mapEvent, ref int __result)
        {
            if (mapEvent.IsPlayerMapEvent
                && battleSide == mapEvent.PlayerSide
                && BannerlordCheatsSettings.Instance?.NoTroopSacrifice == true)
            {
                __result = 0;
            }
        }
    }
}
