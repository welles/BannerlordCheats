using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(ScreenManager), nameof(ScreenManager.PushScreen))]
    public static class EnableHotkeyTipsScreens
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void PushScreen(ref ScreenBase screen)
        {
            try
            {
                if (SettingsManager.EnableHotkeys.Value
                    && SettingsManager.EnableHotkeyTips.Value)
                {
                    switch (screen)
                    {
                        case GauntletInventoryScreen _:
                            Message.Show("Inventory Screen Cheat Hotkeys:");
                            Message.Show("CTRL + X: Add 1.000 gold.");
                            Message.Show("CTRL + SHIFT + X: Add 100.000 gold.");
                            Message.Show("CTRL + H: Add 1 to the selected item type.");
                            Message.Show("CTRL + SHIFT + H: Add 100 to the selected item type.");
                            break;
                        case GauntletClanScreen _:
                            Message.Show("Clan Screen Cheat Hotkeys:");
                            Message.Show("CTRL + X: Add 1.000 influence.");
                            break;
                        case GauntletPartyScreen _:
                            Message.Show("Party Screen Cheat Hotkeys:");
                            Message.Show("CTRL + H: Add 1 soldier to the selected troop.");
                            Message.Show("CTRL + SHIFT + H: Add 10 soldiers to the selected troop.");
                            Message.Show("CTRL + X: Add experience to the selected troop.");
                            break;
                        case GauntletCharacterDeveloperScreen _:
                            Message.Show("Character Screen Cheat Hotkeys:");
                            Message.Show("CTRL + A: Set all character attributes to 10.");
                            Message.Show("CTRL + (1-6): Add 1 point to the attribute at the given index.");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeyTipsScreens));
            }
        }
    }
}
