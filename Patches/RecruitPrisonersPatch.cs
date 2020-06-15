using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(RecruitPrisonersCampaignBehavior), "GetRecruitableNumber")]
    public static class RecruitPrisonersPatch
    {
        [HarmonyPostfix]
        public static void GetRecruitableNumber(CharacterObject character, ref int __result)
        {
            if (character != null
                && !character.IsHero
                && BannerlordCheatsSettings.Instance.InstantPrisonerRecruitment)
            {
                __result = MobileParty.MainParty.PrisonRoster.GetTroopCount(character);
            }
        }
    }
}
