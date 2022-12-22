using System.Reflection;
using System.Text.RegularExpressions;
using BannerlordCheats.Localization;
using JetBrains.Annotations;
using MCM.Abstractions.Base.Global;
using MCM.Common;

namespace BannerlordCheats.Settings
{
    [UsedImplicitly]
    public class BannerlordCheatsGlobalSettings : AttributeGlobalSettings<BannerlordCheatsGlobalSettings>
    {
        public override string Id { get; } = $"BannerlordCheats_v{Assembly.GetExecutingAssembly().GetName().Version.Major}_Global";

        public override string DisplayName { get; }

        public override string FolderName => "Cheats";

        public override string FormatType => "json2";

        public BannerlordCheatsGlobalSettings()
        {
            string modName;
            string global;

            try { modName = L10N.GetText(L10N.Keys.ModName); }
            catch { modName = "Cheats"; }

            try { global = L10N.GetText(L10N.Keys.Global); }
            catch { global = "Global"; }

            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            version = Regex.Replace(version, @"\.0", string.Empty);
            if (!version.Contains(".")) {  version += ".0"; }

            this.DisplayName = $"{modName} {version} ({global})";
        }

        #region General

        [LocalizedSettingPropertyGroup(L10N.Keys.GeneralGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnableHotkeys))]
        public bool EnableHotkeys { get; set; } = SettingsManager.Default.EnableHotkeys;

        [LocalizedSettingPropertyGroup(L10N.Keys.GeneralGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnableHotkeyTips))]
        public bool EnableHotkeyTips { get; set; } = SettingsManager.Default.EnableHotkeyTips;

        #endregion General

        #region Map

        [LocalizedSettingPropertyGroup(L10N.Keys.MapGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(MapSpeedMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float MapSpeedMultiplier { get; set; } = SettingsManager.Default.MapSpeedMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.MapGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(MapVisibilityMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float MapVisibilityMultiplier { get; set; } = SettingsManager.Default.MapVisibilityMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.MapGroupName)]
        [LocalizedSettingPropertyPercent(nameof(NpcMapSpeedPercentage))]
        public float NpcMapSpeedPercentage { get; set; } = SettingsManager.Default.NpcMapSpeedPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.MapGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyInvisibleOnMap))]
        public bool PartyInvisibleOnMap { get; set; } = SettingsManager.Default.PartyInvisibleOnMap;

        [LocalizedSettingPropertyGroup(L10N.Keys.MapGroupName)]
        [LocalizedSettingPropertyBool(nameof(CaravansInvisibleOnMap))]
        public bool CaravansInvisibleOnMap { get; set; } = SettingsManager.Default.CaravansInvisibleOnMap;

        #endregion Map

        #region Combat - Player

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyPercent(nameof(DamageTakenPercentage))]
        public float DamageTakenPercentage { get; set; } = SettingsManager.Default.DamageTakenPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(Invincible))]
        public bool Invincible { get; set; } = SettingsManager.Default.Invincible;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(PlayerHorseInvincible))]
        public bool PlayerHorseInvincible { get; set; } = SettingsManager.Default.PlayerHorseInvincible;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(OneHitKill))]
        public bool OneHitKill { get; set; } = SettingsManager.Default.OneHitKill;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(AlwaysCrushThroughShields))]
        public bool AlwaysCrushThroughShields { get; set; } = SettingsManager.Default.AlwaysCrushThroughShields;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(SliceThroughEveryone))]
        public bool SliceThroughEveryone { get; set; } = SettingsManager.Default.SliceThroughEveryone;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyPercent(nameof(HealthRegeneration))]
        public float HealthRegeneration { get; set; } = SettingsManager.Default.HealthRegeneration;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(InfiniteAmmo))]
        public bool InfiniteAmmo { get; set; } = SettingsManager.Default.InfiniteAmmo;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(DamageMultiplier), minValue: 1.0f, maxValue: 10.0f)]
        public float DamageMultiplier { get; set; } = SettingsManager.Default.DamageMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(AlwaysKnockDown))]
        public bool AlwaysKnockDown { get; set; } = SettingsManager.Default.AlwaysKnockDown;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(NeverKnockedBackByAttacks))]
        public bool NeverKnockedBackByAttacks { get; set; } = SettingsManager.Default.NeverKnockedBackByAttacks;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoStuckArrows))]
        public bool NoStuckArrows { get; set; } = SettingsManager.Default.NoStuckArrows;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPlayerGroupName)]
        [LocalizedSettingPropertyBool(nameof(InstantCrossbowReload))]
        public bool InstantCrossbowReload { get; set; } = SettingsManager.Default.InstantCrossbowReload;

        #endregion Combat - Player

        #region Combat - Party

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        [LocalizedSettingPropertyDropdown(nameof(PartyKnockoutOrKilled), SettingsManager.Default.PartyKnockoutOrKilled)]
        public Dropdown<LocalizedDropdownValue<KnockoutOrKilled>> PartyKnockoutOrKilled { get; set; } = LocalizedDropdownValue<KnockoutOrKilled>.GenerateDropdown(SettingsManager.Default.PartyKnockoutOrKilled);

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        [LocalizedSettingPropertyDropdown(nameof(CompanionsKnockoutOrKilled), SettingsManager.Default.CompanionsKnockoutOrKilled)]
        public Dropdown<LocalizedDropdownValue<KnockoutOrKilled>> CompanionsKnockoutOrKilled { get; set; } = LocalizedDropdownValue<KnockoutOrKilled>.GenerateDropdown(SettingsManager.Default.CompanionsKnockoutOrKilled);

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyInvincible))]
        public bool PartyInvincible { get; set; } = SettingsManager.Default.PartyInvincible;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyHeroesInvincible))]
        public bool PartyHeroesInvincible { get; set; } = SettingsManager.Default.PartyHeroesInvincible;

        //[LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        //[LocalizedSettingPropertyPercent(nameof(PartyDamageTakenPercentage))]
        public float PartyDamageTakenPercentage { get; set; } = SettingsManager.Default.PartyDamageTakenPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyOneHitKill))]
        public bool PartyOneHitKill { get; set; } = SettingsManager.Default.PartyOneHitKill;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoRunningAway))]
        public bool NoRunningAway { get; set; } = SettingsManager.Default.NoRunningAway;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(PartyHealthRegeneration))]
        public float PartyHealthRegeneration { get; set; } = SettingsManager.Default.PartyHealthRegeneration;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyInfiniteAmmo))]
        public bool PartyInfiniteAmmo { get; set; } = SettingsManager.Default.PartyInfiniteAmmo;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(PartyDamageMultiplier), minValue: 1.0f, maxValue: 10.0f)]
        public float PartyDamageMultiplier { get; set; } = SettingsManager.Default.PartyDamageMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatPartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoFriendlyFire))]
        public bool NoFriendlyFire { get; set; } = SettingsManager.Default.NoFriendlyFire;

        #endregion Combat - Party

        #region Combat - Allies

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatAlliesGroupName)]
        [LocalizedSettingPropertyDropdown(nameof(FriendlyLordsKnockoutOrKilled), SettingsManager.Default.FriendlyLordsKnockoutOrKilled)]
        public Dropdown<LocalizedDropdownValue<KnockoutOrKilled>> FriendlyLordsKnockoutOrKilled { get; set; } = LocalizedDropdownValue<KnockoutOrKilled>.GenerateDropdown(SettingsManager.Default.FriendlyLordsKnockoutOrKilled);

        #endregion Combat - Allies

        #region Combat - Enemies

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatEnemiesGroupName)]
        [LocalizedSettingPropertyDropdown(nameof(EnemyLordsKnockoutOrKilled), SettingsManager.Default.EnemyLordsKnockoutOrKilled)]
        public Dropdown<LocalizedDropdownValue<KnockoutOrKilled>> EnemyLordsKnockoutOrKilled { get; set; } = LocalizedDropdownValue<KnockoutOrKilled>.GenerateDropdown(SettingsManager.Default.EnemyLordsKnockoutOrKilled);

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatEnemiesGroupName)]
        [LocalizedSettingPropertyDropdown(nameof(EnemyTroopsKnockoutOrKilled), SettingsManager.Default.EnemyTroopsKnockoutOrKilled)]
        public Dropdown<LocalizedDropdownValue<KnockoutOrKilled>> EnemyTroopsKnockoutOrKilled { get; set; } = LocalizedDropdownValue<KnockoutOrKilled>.GenerateDropdown(SettingsManager.Default.EnemyTroopsKnockoutOrKilled);

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatEnemiesGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnemiesNoRunningAway))]
        public bool EnemiesNoRunningAway { get; set; } = SettingsManager.Default.EnemiesNoRunningAway;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatEnemiesGroupName)]
        [LocalizedSettingPropertyPercent(nameof(EnemyDamagePercentage))]
        public float EnemyDamagePercentage { get; set; } = SettingsManager.Default.EnemyDamagePercentage;

        #endregion Combat - Enemies

        #region Combat - Misc

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatMiscGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(RenownRewardMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float RenownRewardMultiplier { get; set; } = SettingsManager.Default.RenownRewardMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatMiscGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(InfluenceRewardMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float InfluenceRewardMultiplier { get; set; } = SettingsManager.Default.InfluenceRewardMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatMiscGroupName)]
        [LocalizedSettingPropertyBool(nameof(AlwaysWinBattleSimulation))]
        public bool AlwaysWinBattleSimulation { get; set; } = SettingsManager.Default.AlwaysWinBattleSimulation;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatMiscGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoTroopSacrifice))]
        public bool NoTroopSacrifice { get; set; } = SettingsManager.Default.NoTroopSacrifice;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatMiscGroupName)]
        [LocalizedSettingPropertyInteger(nameof(BanditHideoutTroopLimit), minValue: 0, maxValue: 1000)]
        public int BanditHideoutTroopLimit { get; set; } = SettingsManager.Default.BanditHideoutTroopLimit;

        [LocalizedSettingPropertyGroup(L10N.Keys.CombatMiscGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(CombatZoomMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float CombatZoomMultiplier { get; set; } = SettingsManager.Default.CombatZoomMultiplier;

        #endregion Combat - Misc

        #region Inventory

        [LocalizedSettingPropertyGroup(L10N.Keys.InventoryGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraInventoryCapacity), minValue: 0, maxValue: 1000000)]
        public int ExtraInventoryCapacity { get; set; } = SettingsManager.Default.ExtraInventoryCapacity;

        [LocalizedSettingPropertyGroup(L10N.Keys.InventoryGroupName)]
        [LocalizedSettingPropertyBool(nameof(NativeItemSpawning))]
        public bool NativeItemSpawning { get; set; } = SettingsManager.Default.NativeItemSpawning;

        #endregion Inventory

        #region Party

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraPartyMemberSize), minValue: 0, maxValue: 10000)]
        public int ExtraPartyMemberSize { get; set; } = SettingsManager.Default.ExtraPartyMemberSize;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraPartyPrisonerSize), minValue: 0, maxValue: 10000)]
        public int ExtraPartyPrisonerSize { get; set; } = SettingsManager.Default.ExtraPartyPrisonerSize;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraPartyMorale), minValue: 0, maxValue: 100)]
        public int ExtraPartyMorale { get; set; } = SettingsManager.Default.ExtraPartyMorale;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(InstantEscape))]
        public bool InstantEscape { get; set; } = SettingsManager.Default.InstantEscape;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(FoodConsumptionPercentage))]
        public float FoodConsumptionPercentage { get; set; } = SettingsManager.Default.FoodConsumptionPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(TroopWagesPercentage))]
        public float TroopWagesPercentage { get; set; } = SettingsManager.Default.TroopWagesPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(FreeTroopUpgrades))]
        public bool FreeTroopUpgrades { get; set; } = SettingsManager.Default.FreeTroopUpgrades;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(FreeCompanionHiring))]
        public bool FreeCompanionHiring { get; set; } = SettingsManager.Default.FreeCompanionHiring;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(InstantPrisonerRecruitment))]
        public bool InstantPrisonerRecruitment { get; set; } = SettingsManager.Default.InstantPrisonerRecruitment;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoPrisonerEscape))]
        public bool NoPrisonerEscape { get; set; } = SettingsManager.Default.NoPrisonerEscape;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(PartyHealingMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float PartyHealingMultiplier { get; set; } = SettingsManager.Default.PartyHealingMultiplier;

        #endregion

        #region Clan

        [LocalizedSettingPropertyGroup(L10N.Keys.ClanGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraCompanionLimit), minValue: 0, maxValue: 100)]
        public int ExtraCompanionLimit { get; set; } = SettingsManager.Default.ExtraCompanionLimit;

        [LocalizedSettingPropertyGroup(L10N.Keys.ClanGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraClanPartyLimit), minValue: 0, maxValue: 100)]
        public int ExtraClanPartyLimit { get; set; } = SettingsManager.Default.ExtraClanPartyLimit;

        [LocalizedSettingPropertyGroup(L10N.Keys.ClanGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraClanPartySize), minValue: 0, maxValue: 10000)]
        public int ExtraClanPartySize { get; set; } = SettingsManager.Default.ExtraClanPartySize;

        #endregion Clan

        #region Characters

        [LocalizedSettingPropertyGroup(L10N.Keys.CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(PerfectRelationships))]
        public bool PerfectRelationships { get; set; } = SettingsManager.Default.PerfectRelationships;

        [LocalizedSettingPropertyGroup(L10N.Keys.CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(NeverDieOfOldAge))]
        public bool NeverDieOfOldAge { get; set; } = SettingsManager.Default.NeverDieOfOldAge;

        [LocalizedSettingPropertyGroup(L10N.Keys.CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(BarterOfferAlwaysAccepted))]
        public bool BarterOfferAlwaysAccepted { get; set; } = SettingsManager.Default.BarterOfferAlwaysAccepted;

        [LocalizedSettingPropertyGroup(L10N.Keys.CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoBarterCooldown))]
        public bool NoBarterCooldown { get; set; } = SettingsManager.Default.NoBarterCooldown;

        [LocalizedSettingPropertyGroup(L10N.Keys.CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(ConversationAlwaysSuccessful))]
        public bool ConversationAlwaysSuccessful { get; set; } = SettingsManager.Default.ConversationAlwaysSuccessful;

        [LocalizedSettingPropertyGroup(L10N.Keys.CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(PerfectAttraction))]
        public bool PerfectAttraction { get; set; } = SettingsManager.Default.PerfectAttraction;

        [LocalizedSettingPropertyGroup(L10N.Keys.CharactersGroupName)]
        [LocalizedSettingPropertyBool(nameof(AllowSameSexMarriage))]
        public bool AllowSameSexMarriage { get; set; } = SettingsManager.Default.AllowSameSexMarriage;

        [LocalizedSettingPropertyGroup(L10N.Keys.CharactersGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(PregnancyChanceMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float PregnancyChanceMultiplier { get; set; } = SettingsManager.Default.PregnancyChanceMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.CharactersGroupName)]
        [LocalizedSettingPropertyInteger(nameof(AdjustPregnancyDuration), minValue: 1, maxValue: 36)]
        public int AdjustPregnancyDuration { get; set; } = SettingsManager.Default.AdjustPregnancyDuration;

        #endregion Characters

        #region Kingdom

        [LocalizedSettingPropertyGroup(L10N.Keys.KingdomGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(KingdomDecisionWeightMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float KingdomDecisionWeightMultiplier { get; set; } = SettingsManager.Default.KingdomDecisionWeightMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.KingdomGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoRelationshipLossOnDecision))]
        public bool NoRelationshipLossOnDecision { get; set; } = SettingsManager.Default.NoRelationshipLossOnDecision;

        [LocalizedSettingPropertyGroup(L10N.Keys.KingdomGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoCrimeRatingForCrimes))]
        public bool NoCrimeRatingForCrimes { get; set; } = SettingsManager.Default.NoCrimeRatingForCrimes;

        [LocalizedSettingPropertyGroup(L10N.Keys.PartyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(DecisionOverrideInfluenceCostPercentage))]
        public float DecisionOverrideInfluenceCostPercentage { get; set; } = SettingsManager.Default.DecisionOverrideInfluenceCostPercentage;

        #endregion Kingdom

        #region Experience

        [LocalizedSettingPropertyGroup(L10N.Keys.ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(ExperienceMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float ExperienceMultiplier { get; set; } = SettingsManager.Default.ExperienceMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(CompanionExperienceMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float CompanionExperienceMultiplier { get; set; } = SettingsManager.Default.CompanionExperienceMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(LearningRateMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float LearningRateMultiplier { get; set; } = SettingsManager.Default.LearningRateMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(CompanionLearningRateMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float CompanionLearningRateMultiplier { get; set; } = SettingsManager.Default.CompanionLearningRateMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(LearningLimitMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float LearningLimitMultiplier { get; set; } = SettingsManager.Default.LearningLimitMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(TroopExperienceMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float TroopExperienceMultiplier { get; set; } = SettingsManager.Default.TroopExperienceMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.ExperienceGroupName)]
        [LocalizedSettingPropertyBool(nameof(FreeFocusPointAssignment))]
        public bool FreeFocusPointAssignment { get; set; } = SettingsManager.Default.FreeFocusPointAssignment;

        #endregion Experience

        #region Sieges

        [LocalizedSettingPropertyGroup(L10N.Keys.SiegesGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(SiegeBuildingSpeedMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float SiegeBuildingSpeedMultiplier { get; set; } = SettingsManager.Default.SiegeBuildingSpeedMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.SiegesGroupName)]
        [LocalizedSettingPropertyPercent(nameof(EnemySiegeBuildingSpeedPercentage))]
        public float EnemySiegeBuildingSpeedPercentage { get; set; } = SettingsManager.Default.EnemySiegeBuildingSpeedPercentage;

        #endregion Sieges

        #region Army

        [LocalizedSettingPropertyGroup(L10N.Keys.ArmyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(FactionArmyCohesionLossPercentage))]
        public float FactionArmyCohesionLossPercentage { get; set; } = SettingsManager.Default.FactionArmyCohesionLossPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.ArmyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(ArmyCohesionLossPercentage))]
        public float ArmyCohesionLossPercentage { get; set; } = SettingsManager.Default.ArmyCohesionLossPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.ArmyGroupName)]
        [LocalizedSettingPropertyPercent(nameof(ArmyFoodConsumptionPercentage))]
        public float ArmyFoodConsumptionPercentage { get; set; } = SettingsManager.Default.ArmyFoodConsumptionPercentage;

        #endregion Army

        #region Settlements

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(DisguiseAlwaysWorks))]
        public bool DisguiseAlwaysWorks { get; set; } = SettingsManager.Default.DisguiseAlwaysWorks;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(FreeTroopRecruitment))]
        public bool FreeTroopRecruitment { get; set; } = SettingsManager.Default.FreeTroopRecruitment;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(ItemTradingCostPercentage))]
        public float ItemTradingCostPercentage { get; set; } = SettingsManager.Default.ItemTradingCostPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(SellingPriceMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float SellingPriceMultiplier { get; set; } = SettingsManager.Default.SellingPriceMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(TournamentMaximumBetMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float TournamentMaximumBetMultiplier { get; set; } = SettingsManager.Default.TournamentMaximumBetMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyFoodBonus), minValue: 0, maxValue: 10000)]
        public int DailyFoodBonus { get; set; } = SettingsManager.Default.DailyFoodBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyGarrisonBonus), minValue: 0, maxValue: 10000)]
        public int DailyGarrisonBonus { get; set; } = SettingsManager.Default.DailyGarrisonBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyMilitiaBonus), minValue: 0, maxValue: 10000)]
        public int DailyMilitiaBonus { get; set; } = SettingsManager.Default.DailyMilitiaBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyProsperityBonus), minValue: 0, maxValue: 10000)]
        public int DailyProsperityBonus { get; set; } = SettingsManager.Default.DailyProsperityBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyLoyaltyBonus), minValue: 0, maxValue: 10000)]
        public int DailyLoyaltyBonus { get; set; } = SettingsManager.Default.DailyLoyaltyBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailySecurityBonus), minValue: 0, maxValue: 10000)]
        public int DailySecurityBonus { get; set; } = SettingsManager.Default.DailySecurityBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DailyHearthsBonus), minValue: 0, maxValue: 10000)]
        public int DailyHearthsBonus { get; set; } = SettingsManager.Default.DailyHearthsBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(GarrisonWagesPercentage))]
        public float GarrisonWagesPercentage { get; set; } = SettingsManager.Default.GarrisonWagesPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(NeverRequireCivilianEquipment))]
        public bool NeverRequireCivilianEquipment { get; set; } = SettingsManager.Default.NeverRequireCivilianEquipment;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(ConstructionPowerMultiplier), minValue: 1.0f, maxValue: 1000.0f)]
        public float ConstructionPowerMultiplier { get; set; } = SettingsManager.Default.ConstructionPowerMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoBribeToEnterKeep))]
        public bool NoBribeToEnterKeep { get; set; } = SettingsManager.Default.NoBribeToEnterKeep;

        [LocalizedSettingPropertyGroup(L10N.Keys.SettlementsGroupName)]
        [LocalizedSettingPropertyBool(nameof(SettlementsNeverRebel))]
        public bool SettlementsNeverRebel { get; set; } = SettingsManager.Default.SettlementsNeverRebel;

        #endregion Settlements

        #region Smithing

        [LocalizedSettingPropertyGroup(L10N.Keys.SmithingGroupName)]
        [LocalizedSettingPropertyPercent(nameof(SmithingEnergyCostPercentage))]
        public float SmithingEnergyCostPercentage { get; set; } = SettingsManager.Default.SmithingEnergyCostPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.SmithingGroupName)]
        [LocalizedSettingPropertyBool(nameof(UnlockAllParts))]
        public bool UnlockAllParts { get; set; } = SettingsManager.Default.UnlockAllParts;

        [LocalizedSettingPropertyGroup(L10N.Keys.SmithingGroupName)]
        [LocalizedSettingPropertyPercent(nameof(SmithingDifficultyPercentage))]
        public float SmithingDifficultyPercentage { get; set; } = SettingsManager.Default.SmithingDifficultyPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.SmithingGroupName)]
        [LocalizedSettingPropertyPercent(nameof(SmithingCostPercentage))]
        public float SmithingCostPercentage { get; set; } = SettingsManager.Default.SmithingCostPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CraftedWeaponHandlingBonus), minValue: 0, maxValue: 100)]
        public int CraftedWeaponHandlingBonus { get; set; } = SettingsManager.Default.CraftedWeaponHandlingBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CraftedWeaponSwingDamageBonus), minValue: 0, maxValue: 100)]
        public int CraftedWeaponSwingDamageBonus { get; set; } = SettingsManager.Default.CraftedWeaponSwingDamageBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CraftedWeaponSwingSpeedBonus), minValue: 0, maxValue: 100)]
        public int CraftedWeaponSwingSpeedBonus { get; set; } = SettingsManager.Default.CraftedWeaponSwingSpeedBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CraftedWeaponThrustDamageBonus), minValue: 0, maxValue: 100)]
        public int CraftedWeaponThrustDamageBonus { get; set; } = SettingsManager.Default.CraftedWeaponThrustDamageBonus;

        [LocalizedSettingPropertyGroup(L10N.Keys.SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CraftedWeaponThrustSpeedBonus), minValue: 0, maxValue: 100)]
        public int CraftedWeaponThrustSpeedBonus { get; set; } = SettingsManager.Default.CraftedWeaponThrustSpeedBonus;

        #endregion Smithing

        #region Workshops

        [LocalizedSettingPropertyGroup(L10N.Keys.WorkshopsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(WorkshopBuyingCostPercentage))]
        public float WorkshopBuyingCostPercentage { get; set; } = SettingsManager.Default.WorkshopBuyingCostPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.WorkshopsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(WorkshopDailyExpensePercentage))]
        public float WorkshopDailyExpensePercentage { get; set; } = SettingsManager.Default.WorkshopDailyExpensePercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.WorkshopsGroupName)]
        [LocalizedSettingPropertyPercent(nameof(WorkshopUpgradeCostPercentage))]
        public float WorkshopUpgradeCostPercentage { get; set; } = SettingsManager.Default.WorkshopUpgradeCostPercentage;

        [LocalizedSettingPropertyGroup(L10N.Keys.WorkshopsGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(WorkshopSellingCostMultiplier), minValue: 1.0f, maxValue: 100.0f)]
        public float WorkshopSellingCostMultiplier { get; set; } = SettingsManager.Default.WorkshopSellingCostMultiplier;

        [LocalizedSettingPropertyGroup(L10N.Keys.WorkshopsGroupName)]
        [LocalizedSettingPropertyBool(nameof(EveryoneBuysWorkshops))]
        public bool EveryoneBuysWorkshops { get; set; } = SettingsManager.Default.EveryoneBuysWorkshops;

        #endregion Workshops
    }
}
