using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCombatXpModel), nameof(DefaultCombatXpModel.GetXpFromHit))]
    public static class TroopExperienceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetXpFromHit(
            ref CharacterObject attackerTroop,
            ref CharacterObject captain,
            ref CharacterObject attackedTroop,
            ref PartyBase party,
            ref int damage,
            ref bool isFatal,
            ref CombatXpModel.MissionTypeEnum missionType,
            ref int xpAmount)
        {
            try
            {
                if (party.IsPlayerParty()
                    && !attackerTroop.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.TroopExperienceMultiplier > 1f)
                {
                    xpAmount = (int) Math.Round(xpAmount * BannerlordCheatsSettings.Instance.TroopExperienceMultiplier);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(TroopExperienceMultiplier));
            }
        }
    }
}
