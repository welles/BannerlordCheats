using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTroopRecruitmentCost))]
    public static class FreeTroopRecruitment
    {
        [HarmonyPostfix]
        public static void GetTroopRecruitmentCost(CharacterObject troop, Hero buyerHero, bool withoutItemCost, ref int __result)
        {
            if ((buyerHero?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.FreeTroopRecruitment)
            {
                __result = 0;
            }
        }
    }
}
