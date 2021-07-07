using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), nameof(SandboxAgentStatCalculateModel.GetMaxCameraZoom))]
    public static class CombatZoomMultiplier
    {
        [HarmonyPostfix]
        public static void CrossbowReloadSpeed(ref Agent agent, ref float __result)
        {
            if (agent.IsPlayer()
                && BannerlordCheatsSettings.Instance?.CombatZoomMultiplier > 1f)
            {
                __result *= BannerlordCheatsSettings.Instance.CombatZoomMultiplier;
            }
        }
    }
}
