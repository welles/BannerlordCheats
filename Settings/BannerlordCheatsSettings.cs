﻿using BannerlordCheats.Localization;
using System.Reflection;
using System.Text.RegularExpressions;
using MCM.Abstractions.Settings.Base.PerSave;

namespace BannerlordCheats.Settings
{
    public class BannerlordCheatsSettings : AttributePerSaveSettings<BannerlordCheatsSettings>
    {
        #region Base

        private const string ModName = "ModName";
        private const string CombatPlayerGroupName = "Combat_Player";
        private const string CombatPartyGroupName = "Combat_Party";
        private const string CombatAlliesGroupName = "Combat_Allies";
        private const string CombatEnemiesGroupName = "Combat_Enemies";
        private const string CombatMiscGroupName = "Combat_Misc";
        private const string GeneralGroupName = "General";
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

        public override string Id { get; } = $"BannerlordCheats_v{Assembly.GetExecutingAssembly().GetName().Version.Major}";

        public override string FolderName => "Cheats";

        public override string DisplayName { get; }

        #endregion Base

        public BannerlordCheatsSettings()
        {
            string modName;

            try { modName = L10N.GetText(ModName); }
            catch { modName = "Cheats"; }

            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            version = Regex.Replace(version, @"\.0", string.Empty);
            if (!version.Contains(".")) {  version += ".0"; }

            DisplayName = $"{modName} {version}";
        }

        #region General

        [LocalizedSettingPropertyGroup(GeneralGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnableHotkeys))]
        public bool EnableHotkeys { get; set; } = false;

        [LocalizedSettingPropertyGroup(GeneralGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnableHotkeyTips))]
        public bool EnableHotkeyTips { get; set; } = false;

        #endregion General

        #region Map

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(MapSpeedMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float MapSpeedMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(MapVisibilityMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float MapVisibilityMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyPercent(nameof(NpcMapSpeedPercentage))]
        public float NpcMapSpeedPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyInvisibleOnMap))]
        public bool PartyInvisibleOnMap { get; set; } = false;

        #endregion Map

        #region Combat - Player

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyPercent(nameof(DamageTakenPercentage))]
        public float DamageTakenPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(Invincible))]
        public bool Invincible { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(PlayerHorseInvincible))]
        public bool PlayerHorseInvincible { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(OneHitKill))]
        public bool OneHitKill { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(AlwaysCrushThroughShields))]
        public bool AlwaysCrushThroughShields { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(SliceThroughEveryone))]
        public bool SliceThroughEveryone { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyPercent(nameof(HealthRegeneration))]
        public float HealthRegeneration { get; set; } = 0.0f;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(InfiniteAmmo))]
        public bool InfiniteAmmo { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(DamageMultiplier), minValue: 1.0f, maxValue: 10.0f)]
        public float DamageMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(AlwaysKnockDown))]
        public bool AlwaysKnockDown { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(NeverKnockedBackByAttacks))]
        public bool NeverKnockedBackByAttacks { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoStuckArrows))]
        public bool NoStuckArrows { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(InstantCrossbowReload))]
        public bool InstantCrossbowReload { get; set; } = false;

        #endregion Combat - Player

        #region Combat - Party

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyInvincible))]
        public bool PartyInvincible { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyHeroesInvincible))]
        public bool PartyHeroesInvincible { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(PartyDamageTakenPercentage))]
        public float PartyDamageTakenPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyOneHitKill))]
        public bool PartyOneHitKill { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyOnlyKnockout))]
        public bool PartyOnlyKnockout { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoRunningAway))]
        public bool NoRunningAway { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(PartyHealthRegeneration))]
        public float PartyHealthRegeneration { get; set; } = 0.0f;

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyInfiniteAmmo))]
        public bool PartyInfiniteAmmo { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(PartyDamageMultiplier), minValue: 1.0f, maxValue: 10.0f)]
        public float PartyDamageMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoFriendlyFire))]
        public bool NoFriendlyFire { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatPartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(CompanionDeathPercentage))]
        public float CompanionDeathPercentage { get; set; } = 100.0f;

        #endregion Combat - Party

        #region Combat - Allies

        [LocalizedSettingPropertyGroup(CombatAlliesGroupName)]
        [LocalizedSettingPropertyPercent(nameof(FriendlyLordCombatDeathPercentage))]
        public float FriendlyLordCombatDeathPercentage { get; set; } = 100.0f;

        #endregion Combat - Allies

        #region Combat - Enemies

        [LocalizedSettingPropertyGroup(CombatEnemiesGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnemyOnlyKnockout))]
        public bool EnemyOnlyKnockout { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatEnemiesGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnemiesNoRunningAway))]
        public bool EnemiesNoRunningAway { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatEnemiesGroupName)]
        [LocalizedSettingPropertyPercent(nameof(EnemyDamagePercentage))]
        public float EnemyDamagePercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(CombatEnemiesGroupName)]
        [LocalizedSettingPropertyPercent(nameof(EnemyLordCombatDeathPercentage))]
        public float EnemyLordCombatDeathPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(CombatEnemiesGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(EnemyLordCombatDeathChanceMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float EnemyLordCombatDeathChanceMultiplier { get; set; } = 1.0f;

        #endregion Combat - Enemies

        #region Combat - Misc

        [LocalizedSettingPropertyGroup(CombatMiscGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(RenownRewardMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float RenownRewardMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(CombatMiscGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(InfluenceRewardMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float InfluenceRewardMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(CombatMiscGroupName)]
        [LocalizedSettingPropertyBool(nameof(AlwaysWinBattleSimulation))]
        public bool AlwaysWinBattleSimulation { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatMiscGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoTroopSacrifice))]
        public bool NoTroopSacrifice { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatMiscGroupName)]
        [LocalizedSettingPropertyInteger(nameof(BanditHideoutTroopLimit), minValue: 0, maxValue: 1000)]
        public int BanditHideoutTroopLimit { get; set; } = 0;

        [LocalizedSettingPropertyGroup(CombatMiscGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(CombatZoomMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float CombatZoomMultiplier { get; set; } = 1.0f;

        #endregion Combat - Misc

        #region Inventory

        [LocalizedSettingPropertyGroup(InventoryGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraInventoryCapacity), minValue: 0, maxValue: 1000000)]
        public int ExtraInventoryCapacity { get; set; } = 0;

        [LocalizedSettingPropertyGroup(InventoryGroupName)]
        [LocalizedSettingPropertyBool(nameof(NativeItemSpawning))]
        public bool NativeItemSpawning { get; set; } = false;

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
        public float FoodConsumptionPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(TroopWagesPercentage))]
        public float TroopWagesPercentage { get; set; } = 100.0f;

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
        [LocalizedSettingPropertyFloatingInteger(nameof(PartyHealingMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float PartyHealingMultiplier { get; set; } = 1.0f;

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

        [LocalizedSettingPropertyGroup(CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(PerfectAttraction))]
        public bool PerfectAttraction { get; set; } = false;

        [LocalizedSettingPropertyGroup(CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(AllowSameSexMarriage))]
        public bool AllowSameSexMarriage { get; set; } = false;

        [LocalizedSettingPropertyGroup(CharactersGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(PregnancyChanceMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float PregnancyChanceMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(CharactersGroupName)]
        [LocalizedSettingPropertyInteger(nameof(AdjustPregnancyDuration), minValue: 1, maxValue: 36)]
        public int AdjustPregnancyDuration { get; set; } = 36;

        #endregion Characters

        #region Kingdom

        [LocalizedSettingPropertyGroup(KingdomGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(KingdomDecisionWeightMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float KingdomDecisionWeightMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(KingdomGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoRelationshipLossOnDecision))]
        public bool NoRelationshipLossOnDecision { get; set; } = false;

        [LocalizedSettingPropertyGroup(KingdomGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoCrimeRatingForCrimes))]
        public bool NoCrimeRatingForCrimes { get; set; } = false;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(DecisionOverrideInfluenceCostPercentage))]
        public float DecisionOverrideInfluenceCostPercentage { get; set; } = 100.0f;

        #endregion Kingdom

        #region Experience

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(ExperienceMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float ExperienceMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(CompanionExperienceMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float CompanionExperienceMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(LearningRateMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float LearningRateMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(CompanionLearningRateMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float CompanionLearningRateMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(LearningLimitMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float LearningLimitMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(TroopExperienceMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float TroopExperienceMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyBool(nameof(BannerlordCheatsSettings.FreeFocusPointAssignment))]
        public bool FreeFocusPointAssignment { get; set; } = false;

        #endregion Experience

        #region Sieges

        [LocalizedSettingPropertyGroup(SiegesGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(SiegeBuildingSpeedMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float SiegeBuildingSpeedMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(SiegesGroupName)]
        [LocalizedSettingPropertyPercent(nameof(EnemySiegeBuildingSpeedPercentage))]
        public float EnemySiegeBuildingSpeedPercentage { get; set; } = 100.0f;

        #endregion Sieges

        #region Army

        [LocalizedSettingPropertyGroup(ArmyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(FactionArmyCohesionLossPercentage))]
        public float FactionArmyCohesionLossPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(ArmyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(ArmyCohesionLossPercentage))]
        public float ArmyCohesionLossPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(ArmyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(ArmyFoodConsumptionPercentage))]
        public float ArmyFoodConsumptionPercentage { get; set; } = 100.0f;

        #endregion Army

        #region Settlements

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(DisguiseAlwaysWorks))]
        public bool DisguiseAlwaysWorks { get; set; } = false;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(FreeTroopRecruitment))]
        public bool FreeTroopRecruitment { get; set; } = false;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(ItemTradingCostPercentage))]
        public float ItemTradingCostPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(SellingPriceMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float SellingPriceMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(TournamentMaximumBetMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float TournamentMaximumBetMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyFoodBonus), minValue: 0, maxValue: 10000)]
        public int DailyFoodBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyGarrisonBonus), minValue: 0, maxValue: 10000)]
        public int DailyGarrisonBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyMilitiaBonus), minValue: 0, maxValue: 10000)]
        public int DailyMilitiaBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyProsperityBonus), minValue: 0, maxValue: 10000)]
        public int DailyProsperityBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyLoyaltyBonus), minValue: 0, maxValue: 10000)]
        public int DailyLoyaltyBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailySecurityBonus), minValue: 0, maxValue: 10000)]
        public int DailySecurityBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyHearthsBonus), minValue: 0, maxValue: 10000)]
        public int DailyHearthsBonus { get; set; } = 0;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(GarrisonWagesPercentage))]
        public float GarrisonWagesPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(NeverRequireCivilianEquipment))]
        public bool NeverRequireCivilianEquipment { get; set; } = false;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(ConstructionPowerMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float ConstructionPowerMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoBribeToEnterKeep))]
        public bool NoBribeToEnterKeep { get; set; } = false;

        #endregion Settlements

        #region Smithing

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyPercent(nameof(SmithingEnergyCostPercentage))]
        public float SmithingEnergyCostPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyBool(nameof(UnlockAllParts))]
        public bool UnlockAllParts { get; set; } = false;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyPercent(nameof(SmithingDifficultyPercentage))]
        public float SmithingDifficultyPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyPercent(nameof(SmithingCostPercentage))]
        public float SmithingCostPercentage { get; set; } = 100.0f;

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
        [LocalizedSettingPropertyPercent(nameof(WorkshopBuyingCostPercentage))]
        public float WorkshopBuyingCostPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(WorkshopsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(WorkshopDailyExpensePercentage))]
        public float WorkshopDailyExpensePercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(WorkshopsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(WorkshopUpgradeCostPercentage))]
        public float WorkshopUpgradeCostPercentage { get; set; } = 100.0f;

        [LocalizedSettingPropertyGroup(WorkshopsGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(WorkshopSellingCostMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float WorkshopSellingCostMultiplier { get; set; } = 1.0f;

        [LocalizedSettingPropertyGroup(WorkshopsGroupName)]
        [LocalizedSettingPropertyBool(nameof(EveryoneBuysWorkshops))]
        public bool EveryoneBuysWorkshops { get; set; } = false;

        #endregion Workshops
    }
}
