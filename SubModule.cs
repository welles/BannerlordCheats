using BannerlordCheats.Extensions;
using BannerlordCheats.Models;
using HarmonyLib;
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
        }

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            var harmony = new Harmony("BannerlordCheats");

            harmony.PatchAll();
        }
    }
}
