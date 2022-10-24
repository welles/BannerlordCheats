using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using static TaleWorlds.Core.Crafting;

namespace BannerlordCheats.Patches.Smithing
{
    [HarmonyPatch(typeof(DefaultSmithingModel), nameof(DefaultSmithingModel.GetModifierChanges))]
    public static class CraftedWeaponModifierBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetModifierChanges(int modifierTier, ref OverrideData result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.CraftedWeaponHandlingBonus > 0)
                {
                    result.Handling += BannerlordCheatsSettings.Instance.CraftedWeaponHandlingBonus;
                }

                if (BannerlordCheatsSettings.Instance?.CraftedWeaponSwingDamageBonus > 0)
                {
                    result.SwingDamageOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponSwingDamageBonus;
                }

                if (BannerlordCheatsSettings.Instance?.CraftedWeaponSwingSpeedBonus > 0)
                {
                    result.SwingSpeedOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponSwingSpeedBonus;
                }

                if (BannerlordCheatsSettings.Instance?.CraftedWeaponThrustDamageBonus > 0)
                {
                    result.ThrustDamageOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponThrustDamageBonus;
                }

                if (BannerlordCheatsSettings.Instance?.CraftedWeaponThrustSpeedBonus > 0)
                {
                    result.ThrustSpeedOverriden += BannerlordCheatsSettings.Instance.CraftedWeaponThrustSpeedBonus;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(CraftedWeaponModifierBonus));
            }
        }
    }
}
