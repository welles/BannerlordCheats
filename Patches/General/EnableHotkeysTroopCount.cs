using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection.Party;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(GameManagerBase), nameof(GameManagerBase.OnTick))]
    public static class EnableHotkeysTroopCount
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(
            ref float dt)
        {
            try
            {
                if (!(ScreenManager.TopScreen is GauntletPartyScreen)
                    || BannerlordCheatsSettings.Instance?.EnableHotkeys != true) return;
                if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.LeftShift, InputKey.H))
                {
                    AddTroops(10);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.H))
                {
                    AddTroops(1);
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

            var partyVm = partyScreen.GetViewModel<PartyVM>();

            var selectedCharacter = partyVm.CurrentCharacter;

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
