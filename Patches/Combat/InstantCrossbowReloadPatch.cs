using BannerlordCheats.Extensions;
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
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.InstantCrossbowReload, out var instantCrossbowReload)
                && instantCrossbowReload
                && agent.IsPlayer())
            {
                agentDrivenProperties.ReloadSpeed = 10f;
            }
        }
    }
}
