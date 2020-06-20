using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetGoldCostForUpgrade))]
    public static class FreeTroopUpgradesPatch
    {
        [HarmonyPostfix]
        public static void GetGoldCostForUpgrade(CharacterObject characterObject, CharacterObject upgradeTarget, ref int __result)
        {
            var playerTeam = PartyBase.MainParty?.MemberRoster?.Select(x => x.Character?.Id).ToArray();

            if (playerTeam != null
                && characterObject?.Id != null
                && (playerTeam.Contains(characterObject?.Id))
                && BannerlordCheatsSettings.Instance.FreeTroopUpgrades)
            {
                __result = 0;
            }
        }
    }
}
