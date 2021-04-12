using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultGenericXpModel), nameof(DefaultGenericXpModel.GetXpMultiplier))]
    public static class ExperienceMultiplierPatch
    {
        [HarmonyPostfix]
        public static void GetXpMultiplier(Hero hero, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.ExperienceMultiplier, out var experienceMultiplier)
                && hero.IsPlayer()
                && (Campaign.Current?.GameStarted ?? false))
            {
                __result *= experienceMultiplier;
            }
        }
    }
}
