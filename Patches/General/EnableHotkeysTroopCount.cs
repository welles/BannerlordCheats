using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class EnableHotkeysTroopCount
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            try
            {
                if (ScreenManager.TopScreen is GauntletPartyScreen
                    && BannerlordCheatsSettings.Instance?.EnableHotkeys == true)
                {
                    if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.LeftShift, InputKey.H))
                    {
                        EnableHotkeysTroopCount.AddTroops(10);
                    }
                    else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.H))
                    {
                        EnableHotkeysTroopCount.AddTroops(1);
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysTroopCount));
            }
        }

        private static void AddTroops(int count)
        {
            var partyScreen = ScreenManager.TopScreen as GauntletPartyScreen;

            var partyVM = partyScreen.GetViewModel<PartyVM>();

            var selectedCharacter = partyVM.CurrentCharacter;

            if (selectedCharacter.IsHero) { return; }

            if (selectedCharacter.IsPrisoner)
            {
                PartyBase.MainParty.AddPrisoner(selectedCharacter.Character, count);
            }
            else
            {
                PartyBase.MainParty.AddMember(selectedCharacter.Character, count);
            }

            var newTroop = selectedCharacter.Troop;
            newTroop.Number += count;
            selectedCharacter.Troop = newTroop;

            selectedCharacter.UpdateTradeData();

            selectedCharacter.ThrowOnPropertyChanged();

            var message = string.Format(L10N.GetText("AddTroopsMessage"), count, selectedCharacter.Name);

            Message.Show(message);
        }
    }
}
