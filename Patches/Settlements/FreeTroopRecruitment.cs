using BannerlordCheats.Extensions;
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
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.FreeTroopRecruitment, out var freeTroopRecruitment)
                && freeTroopRecruitment
                && buyerHero.IsPlayer())
            {
                __result = 1;
            }
        }
    }
}
