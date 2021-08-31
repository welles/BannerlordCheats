using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class EnableHotkeysAddItems
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            if (ScreenManager.TopScreen is InventoryGauntletScreen
                && BannerlordCheatsSettings.Instance?.EnableHotkeys == true)
            {
                if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.LeftShift, InputKey.H))
                {
                    EnableHotkeysAddItems.AddItems(100);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.H))
                {
                    EnableHotkeysAddItems.AddItems(1);
                }
            }
        }

        private static void AddItems(int count)
        {
            var inventoryScreen = ScreenManager.TopScreen as InventoryGauntletScreen;

            var inventoryVM = inventoryScreen.GetViewModel<SPInventoryVM>();

            var selectedItem = inventoryVM.GetSelectedItem();

            if (selectedItem == null) { return; }

            var index = TaleWorlds.CampaignSystem.PartyBase.MainParty.ItemRoster.FindIndexOfElement(selectedItem.ItemRosterElement.EquipmentElement);

            if (index < 0) { return; }

            TaleWorlds.CampaignSystem.PartyBase.MainParty.ItemRoster.AddToCounts(selectedItem.ItemRosterElement.EquipmentElement, count);

            selectedItem.ItemCount += count;

            var message = string.Format(L10N.GetText("AddItemsMessage"), count, selectedItem.ItemDescription);

            InformationManager.DisplayMessage(new InformationMessage(message, Color.White));
        }
    }
}
