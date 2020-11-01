using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), "GetPerkEffectsOnAgent")]
    public static class InstantCrossbowReloadPatch
    {
        [HarmonyPrefix]
        public static void GetPerkEffectsOnAgent(ref Agent agent, ref AgentDrivenProperties agentDrivenProperties, ref WeaponComponentData rightHandEquippedItem)
        {
            if (agent != null && agent.IsMainAgent && BannerlordCheatsSettings.Instance.InstantCrossbowReload)
            {
                agentDrivenProperties.ReloadSpeed = 10f;
            }
        }
    }
}
