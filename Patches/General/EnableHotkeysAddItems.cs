using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(GameManagerBase), nameof(GameManagerBase.OnTick))]
    public static class EnableHotkeysAddItems
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(
            ref float dt)
        {
            try
            {
                if (!(ScreenManager.TopScreen is GauntletInventoryScreen)
                    || BannerlordCheatsSettings.Instance?.EnableHotkeys != true) return;
                if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.LeftShift, InputKey.H))
                {
                    AddItems(100);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.H))
                {
                    AddItems(1);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysAddItems));
            }
        }

        private static void AddItems(int count)
        {
            var inventoryScreen = ScreenManager.TopScreen as GauntletInventoryScreen;

            var inventoryVm = inventoryScreen.GetViewModel<SPInventoryVM>();

            var selectedItem = inventoryVm.GetSelectedItem();

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
