using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCombatXpModel), nameof(DefaultCombatXpModel.GetXpFromHit))]
    public static class TroopExperienceMultiplierPatch
    {
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
            if (BannerlordCheatsSettings.Instance.TroopExperienceMultiplier > 1
                && (party?.Leader?.IsPlayerCharacter ?? false)
                && !attackerTroop.IsPlayerCharacter)
            {
                xpAmount *= BannerlordCheatsSettings.Instance.TroopExperienceMultiplier;
            }
        }
    }
}
