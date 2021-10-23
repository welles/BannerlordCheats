using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultPregnancyModel), nameof(DefaultPregnancyModel.GetDailyChanceOfPregnancyForHero))]
    public static class PregnancyChanceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetDailyChanceOfPregnancyForHero(
            ref Hero hero,
            ref float __result)
        {
            if (BannerlordCheatsSettings.Instance?.PregnancyChanceMultiplier > 1.0f
                && (hero.IsPlayer() || hero.Spouse.IsPlayer()))
            {
                __result *= BannerlordCheatsSettings.Instance.PregnancyChanceMultiplier;
            }
        } 
        
    }
}