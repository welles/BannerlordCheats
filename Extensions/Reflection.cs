using System.Reflection;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Extensions
{
    public static class Reflection
    {
        private static readonly BindingFlags BindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        public static T GetViewModel<T>(this ScreenBase screen)
        {
            FieldInfo field = screen.GetType().GetField("_dataSource", BindingFlags);

            return (T)field.GetValue(screen);
        }

        public static void InitializeTroopLists(this PartyVM partyVM)
        {
            MethodInfo method = partyVM.GetType().GetMethod("InitializeTroopLists", BindingFlags);

            method.Invoke(partyVM, new object[0]);
        }

        public static SPItemVM GetSelectedItem(this SPInventoryVM inventoryVM)
        {
            FieldInfo field = inventoryVM.GetType().GetField("_selectedItem", BindingFlags);

            return (SPItemVM) field.GetValue(inventoryVM);
        }
    }
}
