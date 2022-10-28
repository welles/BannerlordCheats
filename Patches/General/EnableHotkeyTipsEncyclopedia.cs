using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.View.Map;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(MapScreen), nameof(MapScreen.OpenEncyclopedia))]
    public static class EnableHotkeyTipsEncyclopedia
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OpenEncyclopedia()
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.EnableHotkeys == true
                    && BannerlordCheatsSettings.Instance?.EnableHotkeyTips == true)
                {
                    Message.Show("Encyclopedia Screen Cheat Hotkeys:");
                    Message.Show("CTRL + H: Add 1 soldier of the selected troop type to the party.");
                    Message.Show("CTRL + SHIFT + H: Add 10 soldiers of the selected troop type to the party.");
                    Message.Show("CTRL + X: Kill the selected character.");
                    Message.Show("CTRL + H: Transfer ownership of settlement to you.");
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeyTipsEncyclopedia));
            }
        }
    }
}
