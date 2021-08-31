using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecidePassiveAttackCollisionReaction))]
    public static class SliceThroughEveryonePassive
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecidePassiveAttackCollisionReaction(
            ref Agent attacker,
            ref Agent defender,
            ref bool isFatalHit,
            ref MeleeCollisionReaction __result)
        {
            if (attacker.IsPlayer()
                && BannerlordCheatsSettings.Instance?.SliceThroughEveryone == true)
            {
                __result = MeleeCollisionReaction.SlicedThrough;
            }
        }
    }
}
