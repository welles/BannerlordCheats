using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection.Party;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class EnableHotkeysTroopExperience
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            try
            {
                if (ScreenManager.TopScreen is GauntletPartyScreen
                    && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X)
                    && BannerlordCheatsSettings.Instance?.EnableHotkeys == true)
                {
                    var partyScreen = ScreenManager.TopScreen as GauntletPartyScreen;

                    var partyVM = partyScreen.GetViewModel<PartyVM>();

                    var selectedCharacter = partyVM.CurrentCharacter;

                    if (selectedCharacter.IsHero || !selectedCharacter.IsUpgradableTroop) { return; }

                    var index = PartyBase.MainParty.MemberRoster.FindIndexOfTroop(selectedCharacter.Character);

                    var missingXp = selectedCharacter.MaxXP * selectedCharacter.Number - selectedCharacter.CurrentXP;

                    PartyBase.MainParty.MemberRoster.AddXpToTroopAtIndex(missingXp, index);

                    var newTroop = selectedCharacter.Troop;
                    newTroop.Xp = selectedCharacter.MaxXP * selectedCharacter.Number;
                    selectedCharacter.Troop = newTroop;

                    selectedCharacter.InitializeUpgrades();

                    var message = string.Format(L10N.GetText("AddTroopXpMessage"), selectedCharacter.Name);

                    Message.Show(message);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysTroopExperience));
            }
        }
    }
}
