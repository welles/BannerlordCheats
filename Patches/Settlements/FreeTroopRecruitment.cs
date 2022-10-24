using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTroopRecruitmentCost))]
    public static class FreeTroopRecruitment
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetTroopRecruitmentCost(CharacterObject troop, Hero buyerHero, bool withoutItemCost, ref int result)
        {
            try
            {
                if (buyerHero.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.FreeTroopRecruitment == true)
                {
                    result = 1;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(FreeTroopRecruitment));
            }
        }
    }
}
