using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartyTroopUpgradeModel), nameof(DefaultPartyTroopUpgradeModel.GetGoldCostForUpgrade))]
    public static class FreeTroopUpgradesPatch
    {
        [HarmonyPostfix]
        public static void GetGoldCostForUpgrade(ref PartyBase party, ref CharacterObject characterObject, ref CharacterObject upgradeTarget, ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.FreeTroopUpgrades, out var freeTroopUpgrades)
                && freeTroopUpgrades
                && party.IsPlayerParty())
            {
                __result = 0;
            }
        }
    }
}
