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
            if (hero.IsPlayer()
                && (Campaign.Current?.GameStarted ?? false)
                && BannerlordCheatsSettings.Instance.ExperienceMultiplier > 1)
            {
                __result *= BannerlordCheatsSettings.Instance.ExperienceMultiplier;
            }
        }
    }
}
