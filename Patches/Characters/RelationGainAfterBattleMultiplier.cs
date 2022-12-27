using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.MapEvents;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.GetPlayerGainedRelationAmount))]
    public static class RelationGainAfterBattleMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPlayerGainedRelationAmount(
            ref MapEvent mapEvent,
            ref Hero hero,
            ref int __result)
        {
            if (SettingsManager.RelationGainAfterBattleMultiplier.IsChanged)
            {
                __result = (int)Math.Round(__result * SettingsManager.RelationGainAfterBattleMultiplier.Value);
            }
        }
    }
}