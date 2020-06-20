using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace BannerlordCheats.Settings
{
    public class BannerlordCheatsSettings : MCM.Abstractions.Settings.Base.Global.AttributeGlobalSettings<BannerlordCheatsSettings>
    {
        #region Base

        private const int SettingsVersion = 1;

        public override string Id { get; } = $"BannerlordCheats_v{SettingsVersion}";

        public override string FolderName => "Cheats";

        public override string DisplayName => "Cheats";

        #endregion Base

        #region Hotkeys

        [SettingPropertyGroup("Hotkeys")]
        [SettingPropertyBool("Enable Hotkeys", RequireRestart = false, HintText = "Enable cheat hotkeys in inventory screen, party screen, clan screen etc.")]
        public bool EnableHotkeys { get; set; } = false;

        #endregion Hotkeys

        #region Map

        [SettingPropertyGroup("Map")]
        [SettingPropertyFloatingInteger(displayName: "Map Speed Factor", minValue: 1f, maxValue: 100f, RequireRestart = false, HintText = "Factor by which the speed of the player on the map is multiplied. A factor of 1 means default speed.")]
        public float MapSpeedFactor { get; set; } = 1.0f;

        [SettingPropertyGroup("Map")]
        [SettingPropertyFloatingInteger(displayName: "Map Visibility Factor", minValue: 1f, maxValue: 10f, RequireRestart = false, HintText = "Factor by which the visibility range of the player on the map is multiplied. A factor of 1 means default visibility. WARNING: Will negatively affect performance!")]
        public float MapVisibilityFactor { get; set; } = 1.0f;

        #endregion Map

        #region Combat

        [SettingPropertyGroup("Combat")]
        [SettingPropertyBool(displayName: "Invincible", RequireRestart = false, HintText = "Disables all damage to the player character.")]
        public bool Invincible { get; set; } = false;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyBool(displayName: "Party Invincible", RequireRestart = false, HintText = "Disables all damage to members of the player's party.")]
        public bool PartyInvincible { get; set; } = false;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyBool(displayName: "One Hit Kill", RequireRestart = false, HintText = "Kill enemies with one hit.")]
        public bool OneHitKill { get; set; } = false;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyBool(displayName: "Party One Hit Kill", RequireRestart = false, HintText = "Party members kill enemies with one hit.")]
        public bool PartyOneHitKill { get; set; } = false;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyBool(displayName: "Party Only Knockout", RequireRestart = false, HintText = "Party members are never killed, only knocked unconcious.")]
        public bool PartyOnlyKnockout { get; set; } = false;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyFloatingInteger(displayName: "Renown Reward Multiplier", minValue: 1f, maxValue: 1000f, RequireRestart = false, HintText = "Factor by which the renown reward after a won battle or tournament is multiplied. A factor of 1 means default renown.")]
        public float RenownRewardMultiplier { get; set; } = 1.0f;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyFloatingInteger(displayName: "Influence Reward Multiplier", minValue: 1f, maxValue: 1000f, RequireRestart = false, HintText = "Factor by which the influence reward after a won battle is multiplied. A factor of 1 means default influence.")]
        public float InfluenceRewardMultiplier { get; set; } = 1.0f;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyBool(displayName: "Always Win Battle Simulation", RequireRestart = false, HintText = "Enemies do no damage to the player party in combat simulations.")]
        public bool AlwaysWinBattleSimulation { get; set; } = false;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyBool(displayName: "No Troop Sacrifice", RequireRestart = false, HintText = "No troop sacrifice when running from an enemy or breaking a siege.")]
        public bool NoTroopSacrifice { get; set; } = false;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyBool(displayName: "No Running Away", RequireRestart = false, HintText = "Troops in the player's party do not run away during combat.")]
        public bool NoRunningAway { get; set; } = false;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyBool(displayName: "Enemies Never Run Away", RequireRestart = false, HintText = "Enemies never run away during combat.")]
        public bool EnemiesNoRunningAway { get; set; } = false;

        [SettingPropertyGroup("Combat")]
        [SettingPropertyInteger(displayName: "Extra Bandit Hideout Troops", minValue: 0, maxValue: 100, RequireRestart = false, HintText = "Additional troops that can join the player in hideout battles. A value of 0 means default troop limit.")]
        public int BanditHideoutTroopLimit { get; set; } = 0;

        #endregion Combat

        #region Inventory

        [SettingPropertyGroup("Inventory")]
        [SettingPropertyInteger(displayName: "Extra Inventory Capacity", minValue: 0, maxValue: 1000000, RequireRestart = false, HintText = "Extra inventory capacity for the player party.")]
        public int ExtraInventoryCapacity { get; set; } = 0;

        #endregion Inventory

        #region Party

        [SettingPropertyGroup("Party")]
        [SettingPropertyInteger(displayName: "Extra Party Member Size", minValue: 0, maxValue: 10000, RequireRestart = false, HintText = "Increase the maximum size for the player party.")]
        public int ExtraPartyMemberSize { get; set; } = 0;

        [SettingPropertyGroup("Party")]
        [SettingPropertyInteger(displayName: "Extra Party Prisoner Size", minValue: 0, maxValue: 10000, RequireRestart = false, HintText = "Increase the maximum amount of prisoners travelling with the party.")]
        public int ExtraPartyPrisonerSize { get; set; } = 0;

        [SettingPropertyGroup("Party")]
        [SettingPropertyInteger(displayName: "Extra Party Morale", minValue: 0, maxValue: 100, RequireRestart = false, HintText = "Increase morale of the player party.")]
        public int ExtraPartyMorale { get; set; } = 0;

        [SettingPropertyGroup("Party")]
        [SettingPropertyBool(displayName: "No Food Consumption", RequireRestart = false, HintText = "Player party does not need food.")]
        public bool NoFoodConsumption { get; set; } = false;

        [SettingPropertyGroup("Party")]
        [SettingPropertyBool(displayName: "No Troop Wages", RequireRestart = false, HintText = "Player party troops are unpaid.")]
        public bool NoTroopWages { get; set; } = false;

        [SettingPropertyGroup("Party")]
        [SettingPropertyBool(displayName: "Free Troop Upgrades", RequireRestart = false, HintText = "Player party troop upgrades are free.")]
        public bool FreeTroopUpgrades { get; set; } = false;

        [SettingPropertyGroup("Party")]
        [SettingPropertyBool(displayName: "Free Companion Hiring", RequireRestart = false, HintText = "Companions require no hiring fee.")]
        public bool FreeCompanionHiring { get; set; } = false;

        [SettingPropertyGroup("Party")]
        [SettingPropertyBool(displayName: "Instant Prisoner Recruitment", RequireRestart = false, HintText = "Prisoners can be instantly recruited.")]
        public bool InstantPrisonerRecruitment { get; set; } = false;

        [SettingPropertyGroup("Party")]
        [SettingPropertyBool(displayName: "No Prisoner Escape", RequireRestart = false, HintText = "Prisoners cannot escape from captivity.")]
        public bool NoPrisonerEscape { get; set; } = false;

        [SettingPropertyGroup("Party")]
        [SettingPropertyFloatingInteger(displayName: "Party Healing Multiplier", minValue: 1.0f, maxValue:100.0f, RequireRestart = false, HintText = "Factor by which the party healing rate is multiplied. A factor of 1 means default healing.")]
        public float PartyHealingMultiplier { get; set; } = 1.0f;

        #endregion

        #region Clan

        [SettingPropertyGroup("Clan")]
        [SettingPropertyInteger(displayName: "Extra Companion Limit", minValue: 0, maxValue: 100, RequireRestart = false, HintText = "Increase the maximum amount of companions in your clan.")]
        public int ExtraCompanionLimit { get; set; } = 0;

        [SettingPropertyGroup("Clan")]
        [SettingPropertyInteger(displayName: "Extra Clan Party Limit", minValue: 0, maxValue: 100, RequireRestart = false, HintText = "Increase the maximum amount of parties in your clan.")]
        public int ExtraClanPartyLimit { get; set; } = 0;

        #endregion Clan

        #region Kingdom

        [SettingPropertyGroup("Kingdom")]
        [SettingPropertyBool(displayName: "Always Win Kingdom Votes", RequireRestart = false, HintText = "The choice the player has voted for in a kingdom decision always wins.")]
        public bool ForceKingdomDecision { get; set; } = false;

        #endregion Kingdom

        #region Experience

        [SettingPropertyGroup("Experience")]
        [SettingPropertyFloatingInteger(displayName: "Experience Multiplier", minValue: 1, maxValue: 10000, RequireRestart = false, HintText = "Factor by which the experience gain of the player is multiplied. A factor of 1 means default experience.")]
        public float ExperienceMultiplier { get; set; } = 1.0f;

        [SettingPropertyGroup("Experience")]
        [SettingPropertyFloatingInteger(displayName: "Learning Rate Multiplier", minValue: 1, maxValue: 10000, RequireRestart = false, HintText = "Factor by which the learning rate of the player is multiplied. A factor of 1 means default learning.")]
        public float LearningRateMultiplier { get; set; } = 1.0f;

        [SettingPropertyGroup("Experience")]
        [SettingPropertyInteger(displayName: "Troop Experience Multiplier", minValue: 1, maxValue: 1000, RequireRestart = false, HintText = "Factor by which the experience gain of the player's troops is multiplied. A factor of 1 means default experience.")]
        public int TroopExperienceMultiplier { get; set; } = 1;

        #endregion Experience

        #region Sieges

        [SettingPropertyGroup("Sieges")]
        [SettingPropertyFloatingInteger(displayName: "Siege Building Speed Multiplier", minValue: 1f, maxValue: 100f, RequireRestart = false, HintText = "Factor by which the speed of siege engine construction on the player party's side is multiplied. A factor of 1 means default build speed.")]
        public float SiegeBuildingSpeedMultiplier { get; set; } = 1.0f;

        #endregion Sieges

        #region Army

        [SettingPropertyGroup("Army")]
        [SettingPropertyBool(displayName: "No Cohesion Loss", RequireRestart = false, HintText = "Cohesion of the army the player has joined is frozen.")]
        public bool NoArmyCohesionLoss { get; set; } = false;

        [SettingPropertyGroup("Army")]
        [SettingPropertyBool(displayName: "No Food Consumption", RequireRestart = false, HintText = "All parties in the army the player has joined do not need food.")]
        public bool NoArmyFoodConsumption { get; set; } = false;

        #endregion Army

        #region Settlements

        [SettingPropertyGroup("Settlements")]
        [SettingPropertyBool(displayName: "Disguise Always Works", RequireRestart = false, HintText = "Sneaking into settlements always succeeds.")]
        public bool DisguiseAlwaysWorks { get; set; } = false;

        [SettingPropertyGroup("Settlements")]
        [SettingPropertyBool(displayName: "One Day Construction", RequireRestart = false, HintText = "Buildings in player settlements are constructed in one day.")]
        public bool OneDayConstruction { get; set; } = false;

        #endregion Settlements

        #region Smithing

        [SettingPropertyGroup("Smithing")]
        [SettingPropertyBool(displayName: "No Energy Cost", RequireRestart = false, HintText = "Disable energy cost for smithing, smelting or refining.")]
        public bool NoSmithingEnergyCost { get; set; } = false;

        [SettingPropertyGroup("Smithing")]
        [SettingPropertyBool(displayName: "Unlock All Parts", RequireRestart = false, HintText = "All smithing parts are unlocked.")]
        public bool UnlockAllParts { get; set; } = false;

        [SettingPropertyGroup("Smithing")]
        [SettingPropertyBool(displayName: "No Smithing Difficulty", RequireRestart = false, HintText = "Smithing difficulty is zero for every design.")]
        public bool NoSmithingDifficulty { get; set; } = false;

        [SettingPropertyGroup("Smithing")]
        [SettingPropertyBool(displayName: "No Materials Cost", RequireRestart = false, HintText = "Smithing materials cost is zero for every design.")]
        public bool NoSmithingCost { get; set; } = false;

        #endregion Smithing
    }
}
