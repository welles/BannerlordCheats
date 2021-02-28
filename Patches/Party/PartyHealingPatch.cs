using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartyHealingModel), nameof(DefaultPartyHealingModel.GetDailyHealingForRegulars))]
    public static class PartyHealingPatchRegulars
    {
        [HarmonyPostfix]
        public static void GetDailyHealingForRegulars(ref MobileParty party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if (party?.IsMainParty ?? false)
            {
                __result.AddFactor(BannerlordCheatsSettings.Instance.PartyHealingMultiplier);
            }
        }
    }

    [HarmonyPatch(typeof(DefaultPartyHealingModel), nameof(DefaultPartyHealingModel.GetDailyHealingHpForHeroes))]
    public static class PartyHealingPatchHeroes
    {
        [HarmonyPostfix]
        public static void GetDailyHealingHpForHeroes(ref MobileParty party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if (party?.IsMainParty ?? false)
            {
                __result.AddFactor(BannerlordCheatsSettings.Instance.PartyHealingMultiplier);
            }
        }
    }
}
