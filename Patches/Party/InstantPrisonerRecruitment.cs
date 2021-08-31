using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPrisonerRecruitmentCalculationModel), nameof(DefaultPrisonerRecruitmentCalculationModel.CalculateRecruitableNumber))]
    public static class InstantPrisonerRecruitment
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void  CalculateRecruitableNumber(ref PartyBase party, ref CharacterObject character, ref int __result)
        {
            if (party.IsPlayerParty()
                && !character.IsHero()
                && BannerlordCheatsSettings.Instance?.InstantPrisonerRecruitment == true)
            {
                __result = party.PrisonRoster.GetTroopCount(character);
            }
        }
    }
}
