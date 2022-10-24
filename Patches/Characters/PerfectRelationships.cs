using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(Hero), nameof(Hero.GetRelation))]
    public static class PerfectRelationships
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRelation(Hero otherHero, ref Hero instance, ref int result)
        {
            try
            {
                if ((instance.IsPlayer() || otherHero.IsPlayer())
                    && BannerlordCheatsSettings.Instance?.PerfectRelationships == true)
                {
                    result = 100;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PerfectRelationships));
            }
        }
    }
}
