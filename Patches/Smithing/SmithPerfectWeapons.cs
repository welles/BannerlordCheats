using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using static TaleWorlds.Core.Crafting;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetModifierChanges))]
    public static class SmithPerfectWeapons
    {
        [HarmonyPostfix]
        public static void GetModifierChanges(int modifierTier, ref OverrideData __result)
        {
            __result.Handling += BannerlordCheatsSettings.Instance.CraftedWeaponHandlingBonus;
            __result.SwingDamageOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponSwingDamageBonus;
            __result.SwingSpeedOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponSwingSpeedBonus;
            __result.ThrustDamageOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponThrustDamageBonus;
            __result.ThrustSpeedOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponThrustSpeedBonus;
        }
    }
}
