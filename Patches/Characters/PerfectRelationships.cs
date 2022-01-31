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
        public static void GetRelation(Hero otherHero, ref Hero __instance, ref int __result)
        {
            try
            {
                if ((__instance.IsPlayer() || otherHero.IsPlayer())
                    && BannerlordCheatsSettings.Instance?.PerfectRelationships == true)
                {
                    __result = 100;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PerfectRelationships));
            }
        }
    }
}
