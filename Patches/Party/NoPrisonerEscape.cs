using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(EndCaptivityAction), nameof(EndCaptivityAction.ApplyByEscape))]
    public static class NoPrisonerEscape
    {
        [HarmonyPrefix]
        public static bool ApplyByEscape(Hero character, Hero facilitator)
        {
            try
            {
                if (character.IsPrisoner
                    && character.PartyBelongedToAsPrisoner != null
                    && character.PartyBelongedToAsPrisoner.MapFaction == Hero.MainHero.MapFaction
                    && BannerlordCheatsSettings.Instance?.NoPrisonerEscape == true)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoPrisonerEscape));

                return true;
            }
        }
    }
}
