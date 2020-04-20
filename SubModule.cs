using BannerlordCheats.Extensions;
using BannerlordCheats.Models;
using SandBox.GauntletUI;
using System;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (gameStarterObject is CampaignGameStarter campaignGameStarter)
            {
                //campaignGameStarter.AddModel(new CheatClanTierModel());
                //campaignGameStarter.AddModel(new CheatPartySizeLimitModel());
                //campaignGameStarter.AddModel(new CheatPartySpeedCalculatingModel());
                //campaignGameStarter.AddModel(new CheatSiegeEventModel());
                //campaignGameStarter.AddModel(new CheatAgentApplyDamageModel());
                //campaignGameStarter.AddModel(new CheatGenericXpModel());
                //campaignGameStarter.AddModel(new CheatInventoryCapacityModel());
                //campaignGameStarter.AddModel(new CheatHeroDeathProbabilityCalculationModel());
                //campaignGameStarter.AddModel(new CheatPartyMoraleModel());
                //campaignGameStarter.AddModel(new CheatCharacterDevelopmentModel());
                //campaignGameStarter.AddModel(new CheatMapVisibilityModel());
                //campaignGameStarter.AddModel(new CheatSmithingModel());
                //campaignGameStarter.AddModel(new CheatBuildingConstructionModel());
                //campaignGameStarter.AddModel(new CheatBattleRewardModel());
                //campaignGameStarter.AddModel(new CheatTroopCountLimitModel());
            }
        }

        protected override void OnApplicationTick(float dt)
        {
            base.OnApplicationTick(dt);

            /*if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.A))
            {
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Control, 10);
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Cunning, 10);
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Endurance, 10);
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Intelligence, 10);
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Social, 10);
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Vigor, 10);

                var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

                charVM.RefreshValues();

                InformationManager.DisplayMessage(new InformationMessage($"{DateTime.Now:HH:mm:ss}: Set attributes of {Hero.MainHero.Name}.", Color.White));
            }*/

            /*if (ScreenManager.TopScreen is GauntletPartyScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X))
            {
                var partyScreen = ScreenManager.TopScreen as GauntletPartyScreen;

                var partyVM = partyScreen.GetViewModel<PartyVM>();

                var selectedCharacter = partyVM.CurrentCharacter;

                var selectedTroops = selectedCharacter.Troops;

                if (selectedCharacter.IsUpgrade1Exists || selectedCharacter.IsUpgrade2Exists)
                {
                    selectedTroops.SetElementXp(selectedCharacter.Index, selectedCharacter.MaxXP * selectedCharacter.Number);

                    partyVM.InitializeTroopLists();

                    InformationManager.DisplayMessage(new InformationMessage($"{DateTime.Now:HH:mm:ss}: Added XP to {selectedCharacter.Name}.", Color.White));
                }
            }*/

            /*if (ScreenManager.TopScreen is GauntletPartyScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.H))
            {
                var partyScreen = ScreenManager.TopScreen as GauntletPartyScreen;

                var partyVM = partyScreen.GetViewModel<PartyVM>();

                var selectedCharacter = partyVM.CurrentCharacter;

                var selectedTroops = selectedCharacter.Troops;

                if (!selectedCharacter.IsHero)
                {
                    selectedTroops.AddToCountsAtIndex(selectedCharacter.Index, 1);

                    partyVM.InitializeTroopLists();

                    InformationManager.DisplayMessage(new InformationMessage($"{DateTime.Now:HH:mm:ss}: Added 1 troop to {selectedCharacter.Name}.", Color.White));
                }
            }*/

            /*if (ScreenManager.TopScreen is InventoryGauntletScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X))
            {
                Hero.MainHero.ChangeHeroGold(1000);

                InformationManager.DisplayMessage(new InformationMessage($"{DateTime.Now:HH:mm:ss}: Added 1000 gold.", Color.White));
            }*/

            /*if (ScreenManager.TopScreen is GauntletClanScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X))
            {
                Hero.MainHero.AddInfluenceWithKingdom(1000);

                InformationManager.DisplayMessage(new InformationMessage($"{DateTime.Now:HH:mm:ss}: Added 1000 influence.", Color.White));
            }*/
        }
    }
}
