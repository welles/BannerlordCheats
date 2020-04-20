using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats
{
    public class SubModule : MBSubModuleBase
    {
        /*protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (gameStarterObject is CampaignGameStarter campaignGameStarter)
            {
                campaignGameStarter.AddModel(new CheatClanTierModel());
                campaignGameStarter.AddModel(new CheatPartySizeLimitModel());
                campaignGameStarter.AddModel(new CheatPartySpeedCalculatingModel());
                campaignGameStarter.AddModel(new CheatSiegeEventModel());
                campaignGameStarter.AddModel(new CheatAgentApplyDamageModel());
                campaignGameStarter.AddModel(new CheatGenericXpModel());
                campaignGameStarter.AddModel(new CheatInventoryCapacityModel());
                campaignGameStarter.AddModel(new CheatHeroDeathProbabilityCalculationModel());
                campaignGameStarter.AddModel(new CheatPartyMoraleModel());
                campaignGameStarter.AddModel(new CheatCharacterDevelopmentModel());
                campaignGameStarter.AddModel(new CheatMapVisibilityModel());
                campaignGameStarter.AddModel(new CheatSmithingModel());
                campaignGameStarter.AddModel(new CheatBuildingConstructionModel());
                campaignGameStarter.AddModel(new CheatBattleRewardModel());
                campaignGameStarter.AddModel(new CheatTroopCountLimitModel());
            }
        }*/

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            var harmony = new Harmony("BannerlordCheats");

            harmony.PatchAll();
        }
    }
}
