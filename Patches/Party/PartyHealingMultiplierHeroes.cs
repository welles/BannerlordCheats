using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartyHealingModel), nameof(DefaultPartyHealingModel.GetDailyHealingHpForHeroes))]
    public static class PartyHealingMultiplierHeroes
    {
        [HarmonyPostfix]
        public static void GetDailyHealingHpForHeroes(ref MobileParty party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.PartyHealingMultiplier, out var partyHealingMultiplier))
            {
                __result.AddMultiplier(partyHealingMultiplier);
            }
        }
    }
}