using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartyTroopUpgradeModel), nameof(DefaultPartyTroopUpgradeModel.GetGoldCostForUpgrade))]
    public static class FreeTroopUpgrades
    {
        [HarmonyPostfix]
        public static void GetGoldCostForUpgrade(ref PartyBase party, ref CharacterObject characterObject, ref CharacterObject upgradeTarget, ref int __result)
        {
            if (party.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.FreeTroopUpgrades == true)
            {
                __result = 0;
            }
        }
    }
}
