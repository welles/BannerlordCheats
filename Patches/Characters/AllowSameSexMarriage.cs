using System;
using System.Collections.Generic;
using System.Linq;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultMarriageModel), nameof(DefaultMarriageModel.IsCoupleSuitableForMarriage))]
    public static class AllowSameSexMarriage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void IsCoupleSuitableForMarriage(
            ref Hero firstHero,
            ref Hero secondHero,
            ref bool result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.AllowSameSexMarriage == true
                    && (firstHero.IsPlayer() || secondHero.IsPlayer()))
                {
                    result = (firstHero.Clan?.Leader != firstHero || secondHero.Clan?.Leader != secondHero)
                               // && firstHero.IsFemale != secondHero.IsFemale
                               && !DiscoverAncestors(firstHero, 3).Intersect(DiscoverAncestors(secondHero, 3)).Any()
                               && firstHero.CanMarry()
                               && secondHero.CanMarry();
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(AllowSameSexMarriage));
            }
        }

        private static IEnumerable<Hero> DiscoverAncestors(Hero hero, int n)
        {
            if (hero == null) yield break;
            yield return hero;
            if (n <= 0) yield break;
            foreach (Hero discoverAncestor in DiscoverAncestors(hero.Mother, n - 1))
                yield return discoverAncestor;
            foreach (Hero discoverAncestor in DiscoverAncestors(hero.Father, n - 1))
                yield return discoverAncestor;
        }
    }
}
