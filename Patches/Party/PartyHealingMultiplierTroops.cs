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
    [HarmonyPatch(typeof(DefaultPartyHealingModel), nameof(DefaultPartyHealingModel.GetDailyHealingForRegulars))]
    public static class PartyHealingMultiplierTroops
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetDailyHealingForRegulars(ref MobileParty party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.PartyHealingMultiplier.IsChanged)
                {
                    __result.AddMultiplier(SettingsManager.PartyHealingMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyHealingMultiplierTroops));
            }
        }
    }
}
