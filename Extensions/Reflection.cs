using System;
using System.Reflection;
using TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;
using TaleWorlds.CampaignSystem.ViewModelCollection.Party;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Extensions
{
    public static class Reflection
    {
        private const BindingFlags BindingFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static;

        public static T GetViewModel<T>(this ScreenBase screen)
        {
            FieldInfo field = screen.GetType().GetField("_dataSource", BindingFlags);

            if (field != null) return (T)field.GetValue(screen);
            return default;
        }

        public static void InitializeTroopLists(this PartyVM partyVm)
        {
            MethodInfo method = partyVm.GetType().GetMethod("InitializeTroopLists", BindingFlags);

            if (method != null) method.Invoke(partyVm, Array.Empty<object>());
        }

        public static SPItemVM GetSelectedItem(this SPInventoryVM inventoryVm)
        {
            FieldInfo field = inventoryVm.GetType().GetField("_selectedItem", BindingFlags);

            if (field != null) return (SPItemVM)field.GetValue(inventoryVm);
            return null;
        }
    }
}
