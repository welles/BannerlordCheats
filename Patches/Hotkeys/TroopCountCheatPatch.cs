using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class TroopCountCheatPatch
    {
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            if (ScreenManager.TopScreen is GauntletPartyScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.LeftShift, InputKey.H) && BannerlordCheatsSettings.Instance.EnableHotkeys)
            {
                AddTroops(10);
            }
            else if (ScreenManager.TopScreen is GauntletPartyScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.H) && BannerlordCheatsSettings.Instance.EnableHotkeys)
            {
                AddTroops(1);
            }
        }

        private static void AddTroops(int count)
        {
            var partyScreen = ScreenManager.TopScreen as GauntletPartyScreen;

            var partyVM = partyScreen.GetViewModel<PartyVM>();

            var selectedCharacter = partyVM.CurrentCharacter;

            if (selectedCharacter.IsHero) { return; }

            var index = PartyBase.MainParty.MemberRoster.FindIndexOfTroop(selectedCharacter.Character);

            PartyBase.MainParty.AddToMemberRosterElementAtIndex(index, count);

            var newTroop = selectedCharacter.Troop;
            newTroop.Number += count;
            selectedCharacter.Troop = newTroop;

            selectedCharacter.UpdateTradeData();

            selectedCharacter.ThrowOnPropertyChanged();

            var message = string.Format(L10N.GetText("AddTroopsMessage"), count, selectedCharacter.Name);

            InformationManager.DisplayMessage(new InformationMessage(message, Color.White));
        }
    }
}
