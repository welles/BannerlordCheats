using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.MountAndBlade;
using static TaleWorlds.CampaignSystem.CombatXpModel;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCombatXpModel), nameof(DefaultCombatXpModel.GetXpFromHit))]
    public static class TroopExperienceMultiplierPatch
    {
        [HarmonyPostfix]
        public static void GetXpFromHit(CharacterObject attackerTroop, CharacterObject attackedTroop, int damage, bool isFatal, MissionTypeEnum missionType, ref int xpAmount)
        {
            if (Mission.Current != null
                && Mission.Current.PlayerTeam != null
                && Mission.Current.PlayerTeam.ActiveAgents.Any(x => x?.Character == attackerTroop))
            {
                xpAmount *= BannerlordCheatsSettings.Instance.TroopExperienceMultiplier;
            }
        }
    }
}
