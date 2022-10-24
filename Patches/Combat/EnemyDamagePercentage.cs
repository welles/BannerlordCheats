using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentApplyDamageModel), nameof(DefaultAgentApplyDamageModel.CalculateDamage))]
    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
    public static class EnemyDamagePercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon, ref float result)
        {
            try
            {
                if (!attackInformation.AttackerAgentOrigin.IsOnPlayerEnemySide()
                    || !(BannerlordCheatsSettings.Instance?.EnemyDamagePercentage < 100f)) return;
                var factor = BannerlordCheatsSettings.Instance.EnemyDamagePercentage / 100f;

                var newValue = (int)Math.Round(factor * result);

                result = newValue;
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnemyDamagePercentage));
            }
        }
    }
}
