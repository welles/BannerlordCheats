using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class EnableHotkeysAddItems
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            try
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
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysAddItems));
            }
        }

        private static void AddItems(int count)
        {
            var inventoryScreen = ScreenManager.TopScreen as InventoryGauntletScreen;

            var inventoryVM = inventoryScreen.GetViewModel<SPInventoryVM>();

            var selectedItem = inventoryVM.GetSelectedItem();

            if (selectedItem == null) { return; }

            var index = PartyBase.MainParty.ItemRoster.FindIndexOfElement(selectedItem.ItemRosterElement.EquipmentElement);

            if (index < 0) { return; }

            PartyBase.MainParty.ItemRoster.AddToCounts(selectedItem.ItemRosterElement.EquipmentElement, count);

            selectedItem.ItemCount += count;

            var message = string.Format(L10N.GetText("AddItemsMessage"), count, selectedItem.ItemDescription);

            Message.Show(message);
        }
    }
}
