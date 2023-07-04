using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    public static class SliceThroughEveryonePassive
    {
        public static void DecidePassiveAttackCollisionReaction(
            ref Agent attacker,
            ref Agent defender,
            ref bool isFatalHit,
            ref MeleeCollisionReaction __result)
        {
            try
            {
                if (attacker.IsPlayer()
                    && SettingsManager.SliceThroughEveryone.IsChanged)
                {
                    __result = MeleeCollisionReaction.SlicedThrough;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(SliceThroughEveryonePassive));
            }
        }
    }

    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecidePassiveAttackCollisionReaction))]
    public static class SliceThroughEveryonePassive_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecidePassiveAttackCollisionReaction(
            ref Agent attacker,
            ref Agent defender,
            ref bool isFatalHit,
            ref MeleeCollisionReaction __result)
            => SliceThroughEveryonePassive.DecidePassiveAttackCollisionReaction(
                ref attacker,
                ref defender,
                ref isFatalHit,
                ref __result);
    }
}
