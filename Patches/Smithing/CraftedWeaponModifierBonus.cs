using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using static TaleWorlds.Core.Crafting;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetModifierChanges))]
    public static class CraftedWeaponModifierBonus
    {
        [HarmonyPostfix]
        public static void GetModifierChanges(int modifierTier, ref OverrideData __result)
        {
            if (BannerlordCheatsSettings.Instance?.CraftedWeaponHandlingBonus > 0)
            {
                __result.Handling += BannerlordCheatsSettings.Instance.CraftedWeaponHandlingBonus;
            }

            if (BannerlordCheatsSettings.Instance?.CraftedWeaponSwingDamageBonus > 0)
            {
                __result.SwingDamageOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponSwingDamageBonus;
            }

            if (BannerlordCheatsSettings.Instance?.CraftedWeaponSwingSpeedBonus > 0)
            {
                __result.SwingSpeedOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponSwingSpeedBonus;
            }

            if (BannerlordCheatsSettings.Instance?.CraftedWeaponThrustDamageBonus > 0)
            {
                __result.ThrustDamageOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponThrustDamageBonus;
            }

            if (BannerlordCheatsSettings.Instance?.CraftedWeaponThrustSpeedBonus > 0)
            {
                __result.ThrustSpeedOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponThrustSpeedBonus;
            }
        }
    }
}
