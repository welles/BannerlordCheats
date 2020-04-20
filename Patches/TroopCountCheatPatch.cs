using BannerlordCheats.Extensions;
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
            if (ScreenManager.TopScreen is GauntletPartyScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.H))
            {
                var partyScreen = ScreenManager.TopScreen as GauntletPartyScreen;

                var partyVM = partyScreen.GetViewModel<PartyVM>();

                var selectedCharacter = partyVM.CurrentCharacter;

                var selectedTroops = selectedCharacter.Troops;

                if (!selectedCharacter.IsHero)
                {
                    selectedTroops.AddToCountsAtIndex(selectedCharacter.Index, 1);

                    partyVM.InitializeTroopLists();

                    InformationManager.DisplayMessage(new InformationMessage($"Added 1 troop to {selectedCharacter.Name}.", Color.White));
                }
            }
        }
    }
}
