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
            __result.Handling += BannerlordCheatsSettings.Instance.CreaftedWeaponValuesBonus;
            __result.SwingDamageOverriden += BannerlordCheatsSettings.Instance.CreaftedWeaponValuesBonus;
            __result.SwingSpeedOverriden  += BannerlordCheatsSettings.Instance.CreaftedWeaponValuesBonus;
            __result.ThrustDamageOverriden  += BannerlordCheatsSettings.Instance.CreaftedWeaponValuesBonus;
            __result.ThrustSpeedOverriden  += BannerlordCheatsSettings.Instance.CreaftedWeaponValuesBonus;
        }
    }
}
