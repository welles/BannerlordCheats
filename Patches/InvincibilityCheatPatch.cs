using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), "CalculateDamage")]
    public static class InvincibilityCheatPatch
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref int __result)
        {
            if (((attackInformation.VictimAgentCharacter?.IsPlayerCharacter ?? false)
                || attackInformation.IsVictimAgentMount && attackInformation.IsVictimAgentRiderAgentMine)
                && BannerlordCheatsSettings.Instance.Invincible)
            {
                __result = 0;
            }
        }
    }
}
