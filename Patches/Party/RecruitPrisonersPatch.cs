using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPrisonerRecruitmentCalculationModel), nameof(DefaultPrisonerRecruitmentCalculationModel.CalculateRecruitableNumber))]
    public static class RecruitPrisonersPatch
    {
        [HarmonyPostfix]
        public static void  CalculateRecruitableNumber(ref PartyBase party, ref CharacterObject character, ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.InstantPrisonerRecruitment, out var instantPrisonerRecruitment)
                && instantPrisonerRecruitment
                && party.IsPlayerParty()
                && !character.IsHero())
            {
                __result = party.PrisonRoster.GetTroopCount(character);
            }
        }
    }
}
