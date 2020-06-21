using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(PrisonerEscapeCampaignBehavior), nameof(PrisonerEscapeCampaignBehavior.DailyHeroTick))]
    public static class NoPrisonerEscapePatch
    {
        [HarmonyPrefix]
        public static bool DailyHeroTick(Hero hero)
        {
            if (hero != null
                && hero.IsPrisoner
                && hero.PartyBelongedToAsPrisoner != null
                && hero.PartyBelongedToAsPrisoner.MapFaction == Hero.MainHero.MapFaction
                && BannerlordCheatsSettings.Instance.NoPrisonerEscape)
            {
                return false;
            }

            return true;
        }
    }
}
