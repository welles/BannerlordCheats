using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultGenericXpModel), nameof(DefaultGenericXpModel.GetXpMultiplier))]
    public static class DefaultGenericXpModelPatch
    {
        [HarmonyPostfix]
        public static void GetXpMultiplier(Hero hero, ref float __result)
        {
            if ((hero?.IsHumanPlayerCharacter ?? false)
                && (Campaign.Current?.GameStarted ?? false)
                && BannerlordCheatsSettings.Instance.ExperienceMultiplier > 1)
            {
                __result *= BannerlordCheatsSettings.Instance.ExperienceMultiplier;
            }
        }
    }
}
