using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Clan
{
    [HarmonyPatch(typeof(Hero), nameof(Hero.GetRelation))]
    public static class PerfectRelationships
    {
        [HarmonyPostfix]
        public static void GetRelation(Hero otherHero, ref Hero __instance, ref int __result)
        {
            if (((__instance?.IsHumanPlayerCharacter ?? false) || (otherHero?.IsHumanPlayerCharacter ?? false))
                && BannerlordCheatsSettings.Instance.PerfectRelationships)
            {
                __result = 100;
            }
        }
    }
}
