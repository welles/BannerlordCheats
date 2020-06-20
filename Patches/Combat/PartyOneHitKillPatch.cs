using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class PartyOneHitKillPatch
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref int __result)
        {
            var playerTeam = Mission.Current?.Teams.SingleOrDefault(x => x.IsPlayerTeam)?.ActiveAgents.Select(x => x.Character);

            if (playerTeam != null
                && attackInformation.AttackerAgentCharacter != null
                && playerTeam.Contains(attackInformation.AttackerAgentCharacter)
                && attackInformation.VictimAgentCharacter != null
                && !attackInformation.IsFriendlyFire
                && BannerlordCheatsSettings.Instance.PartyOneHitKill)
            {
                __result = attackInformation.VictimAgentCharacter.HitPoints;
            }
        }
    }
}
