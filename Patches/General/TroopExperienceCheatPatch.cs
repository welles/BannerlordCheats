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

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class TroopExperienceCheatPatch
    {
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.EnableHotkeys, out var enableHotkeys)
                && enableHotkeys
                && ScreenManager.TopScreen is GauntletPartyScreen
                && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X))
            {
                var partyScreen = ScreenManager.TopScreen as GauntletPartyScreen;

                var partyVM = partyScreen.GetViewModel<PartyVM>();

                var selectedCharacter = partyVM.CurrentCharacter;

                if (selectedCharacter.IsHero || (!selectedCharacter.IsUpgrade1Exists && !selectedCharacter.IsUpgrade2Exists)) { return; }

                var index = PartyBase.MainParty.MemberRoster.FindIndexOfTroop(selectedCharacter.Character);

                var missingXp = selectedCharacter.MaxXP * selectedCharacter.Number - selectedCharacter.CurrentXP;

                PartyBase.MainParty.MemberRoster.AddXpToTroopAtIndex(missingXp, index);

                var newTroop = selectedCharacter.Troop;
                newTroop.Xp = selectedCharacter.MaxXP * selectedCharacter.Number;
                selectedCharacter.Troop = newTroop;

                selectedCharacter.InitializeUpgrades();

                var message = string.Format(L10N.GetText("AddTroopXpMessage"), selectedCharacter.Name);

                InformationManager.DisplayMessage(new InformationMessage(message, Color.White));
            }
        }
    }
}
