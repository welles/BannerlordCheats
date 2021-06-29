using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultGenericXpModel), nameof(DefaultGenericXpModel.GetXpMultiplier))]
    public static class ExperienceMultiplier
    {
        [HarmonyPostfix]
        public static void GetXpMultiplier(Hero hero, ref float __result)
        {
            if (hero.IsPlayer()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.ExperienceMultiplier, out var experienceMultiplier))
            {
                __result *= experienceMultiplier;
            }
        }
    }
}
