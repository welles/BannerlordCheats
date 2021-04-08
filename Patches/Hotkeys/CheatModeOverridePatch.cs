using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Hotkeys
{
    [HarmonyPatch(typeof(Game), nameof(Game.CheatMode), MethodType.Getter)]
    public static class CheatModeOverridePatch
    {
        [HarmonyPostfix]
        public static void CheatMode(ref bool __result)
        {
            __result |= BannerlordCheatsSettings.Instance.OverrideCheatMode;
        }
    }
}
