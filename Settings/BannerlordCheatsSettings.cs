using BannerlordCheats.Localization;
using MCM.Abstractions.Settings.Base.Global;
using System.Reflection;

namespace BannerlordCheats.Settings
{
    public class BannerlordCheatsSettings : AttributeGlobalSettings<BannerlordCheatsSettings>
    {
        #region Base

        private const string ModName = "ModName";
        private const string CombatGroupName = "Combat";
        private const string HotkeysGroupName = "Hotkeys";
        private const string MapGroupName = "Map";
        private const string InventoryGroupName = "Inventory";
        private const string PartyGroupName = "Party";
        private const string ClanGroupName = "Clan";
        private const string KingdomGroupName = "Kingdom";
        private const string ExperienceGroupName = "Experience";
        private const string SiegesGroupName = "Sieges";
        private const string ArmyGroupName = "Army";
        private const string SmithingGroupName = "Smithing";
        private const string SettlementsGroupName = "Settlements";
        private const string CharactersGroupName = "Characters";
        private const string WorkshopsGroupName = "Workshops";

        public override string Id { get; } = $"BannerlordCheats_v{Assembly.GetExecutingAssembly().GetName().Version}";

        public override string FolderName { get; } = "Cheats";

        public override string FormatType { get; } = "json";

        public override string DisplayName { get; }

        public new static BannerlordCheatsSettings Instance => AttributeGlobalSettings<BannerlordCheatsSettings>.Instance;

        #endregion Base

        public BannerlordCheatsSettings()
        {
            string modName;

            try { modName = L10N.GetText(BannerlordCheatsSettings.ModName); }
            catch { modName = "Cheats"; }

            this.DisplayName = $"{modName} {Assembly.GetExecutingAssembly().GetName().Version}";
        }

        #region Hotkeys

        [LocalizedSettingPropertyGroup(HotkeysGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnableHotkeys))]
        public bool EnableHotkeys { get; set; } = false;

        #endregion Hotkeys

        #region Map

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyInteger(nameof(MapSpeedMultiplier), minValue: 1, maxValue: 100)]
        public int MapSpeedMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyInteger(nameof(MapVisibilityMultiplier), minValue: 1, maxValue: 10)]
        public int MapVisibilityMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyPercent(nameof(NpcMapSpeedPercentage))]
        public int NpcMapSpeedPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyInvisibleOnMap))]
        public bool PartyInvisibleOnMap { get; set; } = false;

        #endregion Map

        #region Combat

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyPercent(nameof(DamageTakenPercentage))]
        public int DamageTakenPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(Invincible))]
        public bool Invincible { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyInvincible))]
        public bool PartyInvincible { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyHeroesInvincible))]
        public bool PartyHeroesInvincible { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyPercent(nameof(PartyDamageTakenPercentage))]
        public int PartyDamageTakenPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(OneHitKill))]
        public bool OneHitKill { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyOneHitKill))]
        public bool PartyOneHitKill { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyOnlyKnockout))]
        public bool PartyOnlyKnockout { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnemyOnlyKnockout))]
        public bool EnemyOnlyKnockout { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyInteger(nameof(RenownRewardMultiplier), minValue: 1, maxValue: 1000)]
        public int RenownRewardMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyInteger(nameof(InfluenceRewardMultiplier), minValue: 1, maxValue: 1000)]
        public int InfluenceRewardMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(AlwaysWinBattleSimulation))]
        public bool AlwaysWinBattleSimulation { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoTroopSacrifice))]
        public bool NoTroopSacrifice { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoRunningAway))]
        public bool NoRunningAway { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnemiesNoRunningAway))]
        public bool EnemiesNoRunningAway { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyInteger(nameof(BanditHideoutTroopLimit), minValue: 0, maxValue: 1000)]
        public int BanditHideoutTroopLimit { get; set; } = 0;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(AlwaysCrushThroughShields))]
        public bool AlwaysCrushThroughShields { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyPercent(nameof(HealthRegeneration))]
        public int HealthRegeneration { get; set; } = 0;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyPercent(nameof(PartyHealthRegeneration))]
        public int PartyHealthRegeneration { get; set; } = 0;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(InfiniteAmmo))]
        public bool InfiniteAmmo { get; set; } = false;

        // [LocalizedSettingPropertyGroup(CombatGroupName)]
        // [LocalizedSettingPropertyBool(nameof(PartyInfiniteAmmo))]
        // public bool PartyInfiniteAmmo { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(DamageMultiplier), minValue: 1.0f, maxValue: 10.0f)]
        public float DamageMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(PartyDamageMultiplier), minValue: 1.0f, maxValue: 10.0f)]
        public float PartyDamageMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoFriendlyFire))]
        public bool NoFriendlyFire { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CombatZoomMultiplier), minValue: 1, maxValue: 1000)]
        public int CombatZoomMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(InstantCrossbowReload))]
        public bool InstantCrossbowReload { get; set; } = false;

        #endregion Combat

        #region Inventory

        [LocalizedSettingPropertyGroup(InventoryGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraInventoryCapacity), minValue: 0, maxValue: 1000000)]
        public int ExtraInventoryCapacity { get; set; } = 0;

        #endregion Inventory

        #region Party

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraPartyMemberSize), minValue: 0, maxValue: 10000)]
        public int ExtraPartyMemberSize { get; set; } = 0;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraPartyPrisonerSize), minValue: 0, maxValue: 10000)]
        public int ExtraPartyPrisonerSize { get; set; } = 0;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraPartyMorale), minValue: 0, maxValue: 100)]
        public int ExtraPartyMorale { get; set; } = 0;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(InstantEscape))]
        public bool InstantEscape { get; set; } = false;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(FoodConsumptionPercentage))]
        public int FoodConsumptionPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(TroopWagesPercentage))]
        public int TroopWagesPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(FreeTroopUpgrades))]
        public bool FreeTroopUpgrades { get; set; } = false;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(FreeCompanionHiring))]
        public bool FreeCompanionHiring { get; set; } = false;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(InstantPrisonerRecruitment))]
        public bool InstantPrisonerRecruitment { get; set; } = false;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoPrisonerEscape))]
        public bool NoPrisonerEscape { get; set; } = false;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyInteger(nameof(PartyHealingMultiplier), minValue: 1, maxValue: 100)]
        public int PartyHealingMultiplier { get; set; } = 1;

        #endregion

        #region Clan

        [LocalizedSettingPropertyGroup(ClanGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraCompanionLimit), minValue: 0, maxValue: 100)]
        public int ExtraCompanionLimit { get; set; } = 0;

        [LocalizedSettingPropertyGroup(ClanGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraClanPartyLimit), minValue: 0, maxValue: 100)]
        public int ExtraClanPartyLimit { get; set; } = 0;

        [LocalizedSettingPropertyGroup(ClanGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraClanPartySize), minValue: 0, maxValue: 10000)]
        public int ExtraClanPartySize { get; set; } = 0;

        #endregion Clan

        #region Characters

        [LocalizedSettingPropertyGroup(CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(PerfectRelationships))]
        public bool PerfectRelationships { get; set; } = false;

        [LocalizedSettingPropertyGroup(CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(BarterOfferAlwaysAccepted))]
        public bool BarterOfferAlwaysAccepted { get; set; } = false;

        [LocalizedSettingPropertyGroup(CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoBarterCooldown))]
        public bool NoBarterCooldown { get; set; } = false;

        [LocalizedSettingPropertyGroup(CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(ConversationAlwaysSuccessful))]
        public bool ConversationAlwaysSuccessful { get; set; } = false;

        #endregion Characters

        #region Kingdom

        [LocalizedSettingPropertyGroup(KingdomGroupName)]
        [LocalizedSettingPropertyInteger(nameof(KingdomDecisionWeightMultiplier), minValue: 1, maxValue: 1000)]
        public int KingdomDecisionWeightMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(KingdomGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoRelationshipLossOnDecision))]
        public bool NoRelationshipLossOnDecision { get; set; } = false;

        [LocalizedSettingPropertyGroup(KingdomGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoCrimeRatingForCrimes))]
        public bool NoCrimeRatingForCrimes { get; set; } = false;

        #endregion Kingdom

        #region Experience

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExperienceMultiplier), minValue: 1, maxValue: 1000)]
        public int ExperienceMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyInteger(nameof(LearningRateMultiplier), minValue: 1, maxValue: 1000)]
        public int LearningRateMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyInteger(nameof(TroopExperienceMultiplier), minValue: 1, maxValue: 1000)]
        public int TroopExperienceMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyBool(nameof(BannerlordCheatsSettings.FreeFocusPointAssignment))]
        public bool FreeFocusPointAssignment { get; set; } = false;

        #endregion Experience

        #region Sieges

        [LocalizedSettingPropertyGroup(SiegesGroupName)]
        [LocalizedSettingPropertyInteger(nameof(SiegeBuildingSpeedMultiplier), minValue: 1, maxValue: 1000)]
        public int SiegeBuildingSpeedMultiplier { get; set; } = 1;
        
        [LocalizedSettingPropertyGroup(SiegesGroupName)]
        [LocalizedSettingPropertyPercent(nameof(EnemySiegeBuildingSpeedPercentage))]
        public int EnemySiegeBuildingSpeedPercentage { get; set; } = 100;

        #endregion Sieges

        #region Army

        [LocalizedSettingPropertyGroup(ArmyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(ArmyCohesionLossPercentage))]
        public int ArmyCohesionLossPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(ArmyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(ArmyFoodConsumptionPercentage))]
        public int ArmyFoodConsumptionPercentage { get; set; } = 100;

        #endregion Army

        #region Settlements

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(DisguiseAlwaysWorks))]
        public bool DisguiseAlwaysWorks { get; set; } = false;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(OneDayConstruction))]
        public bool OneDayConstruction { get; set; } = false;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(FreeTroopRecruitment))]
        public bool FreeTroopRecruitment { get; set; } = false;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(ItemTradingCostPercentage))]
        public int ItemTradingCostPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(SellingPriceMultiplier), minValue: 1, maxValue: 1000)]
        public int SellingPriceMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyFoodBonus), minValue: 0, maxValue: 1000)]
        public int DailyFoodBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyGarrisonBonus), minValue: 0, maxValue: 1000)]
        public int DailyGarrisonBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyMilitiaBonus), minValue: 0, maxValue: 1000)]
        public int DailyMilitiaBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyProsperityBonus), minValue: 0, maxValue: 1000)]
        public int DailyProsperityBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyLoyaltyBonus), minValue: 0, maxValue: 1000)]
        public int DailyLoyaltyBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailySecurityBonus), minValue: 0, maxValue: 1000)]
        public int DailySecurityBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyHearthsBonus), minValue: 0, maxValue: 1000)]
        public int DailyHearthsBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(GarrisonWagesPercentage))]
        public int GarrisonWagesPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(NeverRequireCivilianEquipment))]
        public bool NeverRequireCivilianEquipment { get; set; } = false;

        #endregion Settlements

        #region Smithing

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyPercent(nameof(SmithingEnergyCostPercentage))]
        public int SmithingEnergyCostPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyBool(nameof(UnlockAllParts))]
        public bool UnlockAllParts { get; set; } = false;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyPercent(nameof(SmithingDifficultyPercentage))]
        public int SmithingDifficultyPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyPercent(nameof(SmithingCostPercentage))]
        public int SmithingCostPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CraftedWeaponHandlingBonus), minValue: 0, maxValue: 100)]
        public int CraftedWeaponHandlingBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CraftedWeaponSwingDamageBonus), minValue: 0, maxValue: 100)]
        public int CraftedWeaponSwingDamageBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CraftedWeaponSwingSpeedBonus), minValue: 0, maxValue: 100)]
        public int CraftedWeaponSwingSpeedBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CraftedWeaponThrustDamageBonus), minValue: 0, maxValue: 100)]
        public int CraftedWeaponThrustDamageBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CraftedWeaponThrustSpeedBonus), minValue: 0, maxValue: 100)]
        public int CraftedWeaponThrustSpeedBonus { get; set; } = 0;

        #endregion Smithing

        #region Workshops

        [LocalizedSettingPropertyGroup(WorkshopsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(WorkshopDailyExpensePercentage))]
        public int WorkshopDailyExpensePercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(WorkshopsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(WorkshopUpgradeCostPercentage))]
        public int WorkshopUpgradeCostPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(WorkshopsGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(WorkshopSellingCostMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float WorkshopSellingCostMultiplier { get; set; } = 1.0f;

        #endregion Workshops
    }
}
