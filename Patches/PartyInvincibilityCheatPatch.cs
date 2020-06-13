using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), "CalculateDamage")]
    public static class PartyInvincibilityCheatPatch
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref int __result)
        {
            var playerTeam = Mission.Current?.Teams.SingleOrDefault(x => x.IsPlayerTeam)?.ActiveAgents.Select(x => x.Character);

            if (playerTeam != null
                && attackInformation.VictimAgentCharacter != null
                && playerTeam.Contains(attackInformation.VictimAgentCharacter)
                && BannerlordCheatsSettings.Instance.PartyInvincible)
            {
                __result = 0;
            }
        }
    }
}
