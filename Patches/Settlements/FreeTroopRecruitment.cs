using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTroopRecruitmentCost))]
    public static class FreeTroopRecruitment
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetTroopRecruitmentCost(CharacterObject troop, Hero buyerHero, bool withoutItemCost, ref int __result)
        {
            if (buyerHero.IsPlayer()
                && BannerlordCheatsSettings.Instance?.FreeTroopRecruitment == true)
            {
                __result = 1;
            }
        }
    }
}
