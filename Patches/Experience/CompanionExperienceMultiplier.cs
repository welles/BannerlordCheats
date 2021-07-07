using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultGenericXpModel), nameof(DefaultGenericXpModel.GetXpMultiplier))]
    public static class CompanionExperienceMultiplier
    {
        [HarmonyPostfix]
        public static void GetXpMultiplier(ref Hero hero, ref float __result)
        {
            if (!hero.IsPlayer()
                && hero.IsPlayerCompanion()
                && BannerlordCheatsSettings.Instance?.CompanionExperienceMultiplier > 1f)
            {
                __result *= BannerlordCheatsSettings.Instance.CompanionExperienceMultiplier;
            }
        }
    }
}
