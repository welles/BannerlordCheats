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
                if (!(BannerlordCheatsSettings.Instance is { EnableHotkeys: true, EnableHotkeyTips: true })) return;
                Message.Show("Encyclopedia Screen Cheat Hotkeys:");
                Message.Show("CTRL + H: Add 1 soldier of the selected troop type to the party.");
                Message.Show("CTRL + SHIFT + H: Add 10 soldiers of the selected troop type to the party.");
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeyTipsEncyclopedia));
            }
        }
    }
}
