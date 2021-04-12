using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), nameof(SandboxAgentStatCalculateModel.GetMaxCameraZoom))]
    public static class CombatZoomMultiplierPatch
    {
        [HarmonyPostfix]
        public static void CrossbowReloadSpeed(ref Agent agent, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.CombatZoomMultiplier, out var combatZoomMultiplier)
                && agent.IsPlayer())
            {
                __result *= combatZoomMultiplier;
            }
        }
    }
}
