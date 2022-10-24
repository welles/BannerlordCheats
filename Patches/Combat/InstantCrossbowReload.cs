using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), nameof(SandboxAgentStatCalculateModel.UpdateAgentStats))]
    public static class InstantCrossbowReload
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static void UpdateAgentStats(
            ref Agent agent,
            ref AgentDrivenProperties agentDrivenProperties)
        {
            try
            {
                if (agent.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.InstantCrossbowReload == true)
                {
                    agentDrivenProperties.ReloadSpeed = 10f;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(InstantCrossbowReload));
            }
        }
    }
}
