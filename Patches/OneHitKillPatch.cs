using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), "CalculateDamage")]
    public static class OneHitKillPatch
    {
        [HarmonyPostfix]
        public static void CalculateDamage(BasicCharacterObject affectorBasicCharacter, BasicCharacterObject affectedBasicCharacter, MissionWeapon offHandItem, bool isHeadShot, bool isAffectedAgentMount, bool isAffectedAgentHuman, bool hasAffectorAgentMount, bool isAffectedAgentNull, bool isAffectorAgentHuman, AttackCollisionData collisionData, WeaponComponentData weapon, ref int __result)
        {
            if (Mission.Current != null
                && (affectorBasicCharacter?.IsPlayerCharacter ?? false)
                && affectedBasicCharacter != null
                && BannerlordCheatsSettings.Instance.OneHitKill)
            {
                var playerTeam = Mission.Current.Teams.Single(team => team.ActiveAgents.Any(agent => agent.Character == affectorBasicCharacter));
                var targetTeam = Mission.Current.Teams.Single(team => team.ActiveAgents.Any(agent => agent.Character == affectedBasicCharacter));

                if (playerTeam != targetTeam)
                {
                    __result = target.HitPoints;
                }
            }
        }
    }
}
