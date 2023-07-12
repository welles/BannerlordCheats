using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(StartBattleAction), nameof(StartBattleAction.ApplyStartRaid))]
    public static class VillagesNeverRaided
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static bool ApplyStartRaid(
            ref MobileParty attackerParty,
            ref Settlement settlement)
        {
            if (settlement.IsPlayerSettlement()
                && SettingsManager.VillagesNeverRaided.IsChanged)
            {
                return false;
            }

            return true;
        }
    }
}