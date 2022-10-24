using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPrisonerRecruitmentCalculationModel), nameof(DefaultPrisonerRecruitmentCalculationModel.CalculateRecruitableNumber))]
    public static class InstantPrisonerRecruitment
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void  CalculateRecruitableNumber(ref PartyBase party, ref CharacterObject character, ref int result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && !character.IsHero()
                    && BannerlordCheatsSettings.Instance?.InstantPrisonerRecruitment == true)
                {
                    result = party.PrisonRoster.GetTroopCount(character);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(InstantPrisonerRecruitment));
            }
        }
    }
}
