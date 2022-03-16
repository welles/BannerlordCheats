using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), "GetPerkEffectsOnAgent")]
    public static class InstantCrossbowReload
    {
        [HarmonyPrefix]
        public static void GetPerkEffectsOnAgent(ref Agent agent, ref AgentDrivenProperties agentDrivenProperties, ref WeaponComponentData rightHandEquippedItem)
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
