using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), nameof(SandboxAgentStatCalculateModel.GetMaxCameraZoom))]
    public static class CombatZoomMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CrossbowReloadSpeed(ref Agent agent, ref float __result)
        {
            try
            {
                if (agent.IsPlayer()
                    && SettingsManager.CombatZoomMultiplier.IsChanged)
                {
                    __result *= SettingsManager.CombatZoomMultiplier.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(CombatZoomMultiplier));
            }
        }
    }
}
