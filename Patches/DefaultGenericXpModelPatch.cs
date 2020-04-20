using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultGenericXpModel), "GetXpMultiplier")]
    public static class DefaultGenericXpModelPatch
    {
        [HarmonyPostfix]
        public static void GetXpMultiplier(Hero hero, ref float __result)
        {
            if (hero?.IsHumanPlayerCharacter ?? false)
            {
                __result *= BannerlordCheatsSettings.Instance.ExperienceMultiplier;
            }
        }
    }
}
