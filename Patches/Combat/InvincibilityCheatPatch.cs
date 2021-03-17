using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class InvincibilityCheatPatch
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float __result)
        {
            if ((attackInformation.IsVictimAgentMine || (attackInformation.IsVictimAgentMount && attackInformation.IsVictimAgentRiderAgentMine))
                && BannerlordCheatsSettings.Instance.Invincible)
            {
                __result = 0;
            }
        }
    }
}
