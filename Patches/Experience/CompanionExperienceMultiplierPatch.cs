using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultGenericXpModel), nameof(DefaultGenericXpModel.GetXpMultiplier))]
    public static class CompanionExperienceMultiplierPatch
    {
        [HarmonyPostfix]
        public static void GetXpMultiplier(ref Hero hero, ref float __result)
        {
            if ((hero?.IsPlayerCompanion?? false)
                && (Campaign.Current?.GameStarted ?? false)
                && BannerlordCheatsSettings.Instance.CompanionExperienceMultiplier > 1.0f)
            {
                __result *= BannerlordCheatsSettings.Instance.CompanionExperienceMultiplier;
            }
        }
    }
}
