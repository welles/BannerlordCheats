using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartyTroopUpgradeModel), nameof(DefaultPartyTroopUpgradeModel.GetGoldCostForUpgrade))]
    public static class FreeTroopUpgradesPatch
    {
        [HarmonyPostfix]
        public static void GetGoldCostForUpgrade(ref PartyBase party, ref CharacterObject characterObject, ref CharacterObject upgradeTarget, ref int __result)
        {
            if ((party?.Leader?.IsPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.FreeTroopUpgrades)
            {
                __result = 0;
            }
        }
    }
}
