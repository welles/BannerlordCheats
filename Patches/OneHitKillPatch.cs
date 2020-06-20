using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class OneHitKillPatch
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref int __result)
        {
            if ((attackInformation.AttackerAgentCharacter?.IsPlayerCharacter ?? false)
                && !attackInformation.IsFriendlyFire
                && attackInformation.IsVictimAgentHuman
                && BannerlordCheatsSettings.Instance.OneHitKill)
            {
                __result = attackInformation.VictimAgentCharacter.HitPoints;
            }
        }
    }
}
