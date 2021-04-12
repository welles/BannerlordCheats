using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class NoFriendlyFire
    {
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.NoFriendlyFire, out var noFriendlyFire)
                && noFriendlyFire
                && attackInformation.AttackerAgentOrigin.TryGetParty(out var party)
                && party.IsPlayerParty()
                && attackInformation.IsFriendlyFire)
            {
                __result = 0;
            }
        }
    }
}
