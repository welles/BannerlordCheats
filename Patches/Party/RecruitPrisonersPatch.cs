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
            if ((party?.MobileParty?.IsMainParty ?? false)
                && (!character?.IsHero ?? false)
                && BannerlordCheatsSettings.Instance.InstantPrisonerRecruitment)
            {
                __result = MobileParty.MainParty.PrisonRoster.GetTroopCount(character);
            }
        }
    }
}
