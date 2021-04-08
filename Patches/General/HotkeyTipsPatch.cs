using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox.GauntletUI;
using SandBox.View.Map;
using TaleWorlds.Engine.Screens;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(ScreenManager), nameof(ScreenManager.PushScreen))]
    public static class HotkeyTipsPatch
    {
        [HarmonyPostfix]
        public static void PushScreen(ref ScreenBase screen)
        {
            if (BannerlordCheatsSettings.Instance.EnableHotkeys && BannerlordCheatsSettings.Instance.EnableHotkeyTips)
            {
                switch (screen)
                {
                    case InventoryGauntletScreen inventoryGauntletScreen:
                        Message.Show("Inventory Screen Cheat Hotkeys:");
                        Message.Show("CTRL + X: Add 1.000 gold.");
                        Message.Show("CTRL + SHIFT + X: Add 100.000 gold.");
                        Message.Show("CTRL + H: Add 1 to the selected item type.");
                        Message.Show("CTRL + SHIFT + H: Add 100 to the selected item type.");
                        break;
                    case GauntletClanScreen gauntletClanScreen:
                        Message.Show("Clan Screen Cheat Hotkeys:");
                        Message.Show("CTRL + X: Add 1.000 influence.");
                        break;
                    case GauntletPartyScreen gauntletPartyScreen:
                        Message.Show("Party Screen Cheat Hotkeys:");
                        Message.Show("CTRL + H: Add 1 soldier to the selected troop.");
                        Message.Show("CTRL + SHIFT + H: Add 10 soldiers to the selected troop.");
                        Message.Show("CTRL + X: Add experience to the selected troop.");
                        break;
                    case GauntletCharacterDeveloperScreen gauntletCharacterDeveloperScreen:
                        Message.Show("Character Screen Cheat Hotkeys:");
                        Message.Show("CTRL + A: Set all character attributes to 10.");
                        Message.Show("CTRL + (1-6): Add 1 point to the attribute at the given index.");
                        break;
                }
            }
        }
    }

    [HarmonyPatch(typeof(MapScreen), nameof(MapScreen.OpenEncyclopedia))]
    public static class HotkeyTipsPatchEncyclopedia
    {
        [HarmonyPostfix]
        public static void OpenEncyclopedia()
        {
            if (BannerlordCheatsSettings.Instance.EnableHotkeys && BannerlordCheatsSettings.Instance.EnableHotkeyTips)
            {
                Message.Show("Encyclopedia Screen Cheat Hotkeys:");
                Message.Show("CTRL + H: Add 1 soldier of the selected troop type to the party.");
                Message.Show("CTRL + SHIFT + H: Add 10 soldiers of the selected troop type to the party.");
            }
        }
    }
}
