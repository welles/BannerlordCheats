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
    public static class TroopExperienceCheatPatch
    {
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            if (ScreenManager.TopScreen is GauntletPartyScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X))
            {
                var partyScreen = ScreenManager.TopScreen as GauntletPartyScreen;

                var partyVM = partyScreen.GetViewModel<PartyVM>();

                var selectedCharacter = partyVM.CurrentCharacter;

                var selectedTroops = selectedCharacter.Troops;

                if (selectedCharacter.IsUpgrade1Exists || selectedCharacter.IsUpgrade2Exists)
                {
                    selectedTroops.SetElementXp(selectedCharacter.Index, selectedCharacter.MaxXP * selectedCharacter.Number);

                    partyVM.InitializeTroopLists();

                    InformationManager.DisplayMessage(new InformationMessage($"Added XP to {selectedCharacter.Name}.", Color.White));
                }
            }
        }
    }
}
