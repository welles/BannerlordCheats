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
            if (character != null
                && character.IsPrisoner
                && character.PartyBelongedToAsPrisoner != null
                && character.PartyBelongedToAsPrisoner.MapFaction == Hero.MainHero.MapFaction
                && BannerlordCheatsSettings.Instance.NoPrisonerEscape)
            {
                return false;
            }

            return true;
        }
    }
}
