using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class OneHitKillPatch
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float __result)
        {
            if ((attackInformation.AttackerAgentCharacter?.IsPlayerCharacter ?? false)
                && !attackInformation.IsFriendlyFire
                && attackInformation.IsVictimAgentHuman
                && BannerlordCheatsSettings.Instance.OneHitKill)
            {
                __result = 10000;
            }
        }
    }
}
