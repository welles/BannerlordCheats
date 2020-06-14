using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox.GauntletUI;
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

            var selectedTroops = selectedCharacter.Troops;

            // Catch outdated troop index error
            if (selectedCharacter.Index >= selectedTroops.Count)
            {
                partyVM.InitializeTroopLists();

                return;
            }

            if (!selectedCharacter.IsHero)
            {
                selectedTroops.AddToCountsAtIndex(selectedCharacter.Index, count);

                partyVM.InitializeTroopLists();

                InformationManager.DisplayMessage(new InformationMessage($"Added {count} {(count > 1 ? "troops" : "troop")} to {selectedCharacter.Name}.", Color.White));
            }
        }
    }
}
