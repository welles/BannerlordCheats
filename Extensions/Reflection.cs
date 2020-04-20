using System.Reflection;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Engine.Screens;

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

        public static void RefreshPartyInformation(this PartyVM partyVM)
        {
            MethodInfo method = partyVM.GetType().GetMethod("RefreshPartyInformation", BindingFlags);

            method.Invoke(partyVM, new object[0]);
        }

        public static void InitializeTroopLists(this PartyVM partyVM)
        {
            MethodInfo method = partyVM.GetType().GetMethod("InitializeTroopLists", BindingFlags);

            method.Invoke(partyVM, new object[0]);
        }

        public static void RefreshValues(this CharacterDeveloperVM charVM)
        {
            MethodInfo method = charVM.GetType().GetMethod("RefreshValues", BindingFlags);

            method.Invoke(charVM, new object[0]);
        }
    }
}
