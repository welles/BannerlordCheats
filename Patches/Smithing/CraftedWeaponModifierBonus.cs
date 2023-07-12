using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using static TaleWorlds.Core.Crafting;

namespace BannerlordCheats.Patches.Smithing
{
    /*
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetModifierChanges))]
    public static class CraftedWeaponModifierBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetModifierChanges(int modifierTier, ref OverrideData __result)
        {
            try
            {
                if (SettingsManager.CraftedWeaponHandlingBonus.IsChanged)
                {
                    __result.Handling += SettingsManager.CraftedWeaponHandlingBonus.Value;
                }

                if (SettingsManager.CraftedWeaponSwingDamageBonus.IsChanged)
                {
                    __result.SwingDamageOverriden += SettingsManager.CraftedWeaponSwingDamageBonus.Value;
                }

                if (SettingsManager.CraftedWeaponSwingSpeedBonus.IsChanged)
                {
                    __result.SwingSpeedOverriden += SettingsManager.CraftedWeaponSwingSpeedBonus.Value;
                }

                if (SettingsManager.CraftedWeaponThrustDamageBonus.IsChanged)
                {
                    __result.ThrustDamageOverriden += SettingsManager.CraftedWeaponThrustDamageBonus.Value;
                }

                if (SettingsManager.CraftedWeaponThrustSpeedBonus.IsChanged)
                {
                    __result.ThrustSpeedOverriden += SettingsManager.CraftedWeaponThrustSpeedBonus.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(CraftedWeaponModifierBonus));
            }
        }
    }
    */
}
