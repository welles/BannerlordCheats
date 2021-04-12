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
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.CraftedWeaponHandlingBonus, out var craftedWeaponHandlingBonus))
            {
                __result.Handling += craftedWeaponHandlingBonus;
            }

            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.CraftedWeaponSwingDamageBonus, out var craftedWeaponSwingDamageBonus))
            {
                __result.SwingDamageOverriden += craftedWeaponSwingDamageBonus;
            }

            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.CraftedWeaponSwingSpeedBonus, out var craftedWeaponSwingSpeedBonus))
            {
                __result.SwingSpeedOverriden += craftedWeaponSwingSpeedBonus;
            }

            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.CraftedWeaponThrustDamageBonus, out var craftedWeaponThrustDamageBonus))
            {
                __result.ThrustDamageOverriden += craftedWeaponThrustDamageBonus;
            }

            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.CraftedWeaponThrustSpeedBonus, out var craftedWeaponThrustSpeedBonus))
            {
                __result.ThrustSpeedOverriden += craftedWeaponThrustSpeedBonus;
            }
        }
    }
}
