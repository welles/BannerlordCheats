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
            if ((attackInformation.AttackerFormation?.Team?.IsPlayerTeam ?? false)
                && !attackInformation.IsFriendlyFire
                && attackInformation.VictimAgentCharacter != null
                && BannerlordCheatsSettings.Instance.PartyOneHitKill)
            {
                __result = attackInformation.VictimAgentCharacter.HitPoints;
            }
        }
    }
}
