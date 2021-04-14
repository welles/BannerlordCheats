using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(EndCaptivityAction), nameof(EndCaptivityAction.ApplyByEscape))]
    public static class NoPrisonerEscapePatch
    {
        [HarmonyPrefix]
        public static bool ApplyByEscape(Hero character, Hero facilitator)
        {
            if (character.IsPrisoner
                && character.PartyBelongedToAsPrisoner != null
                && character.PartyBelongedToAsPrisoner.MapFaction == Hero.MainHero.MapFaction
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.NoPrisonerEscape, out var noPrisonerEscape)
                && noPrisonerEscape)
            {
                return false;
            }

            return true;
        }
    }
}
