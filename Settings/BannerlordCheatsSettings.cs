using BannerlordCheats.Localization;
using System.Reflection;

namespace BannerlordCheats.Settings
{
    public class BannerlordCheatsSettings : MCM.Abstractions.Settings.Base.Global.AttributeGlobalSettings<BannerlordCheatsSettings>
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

        public override string Id { get; } = $"BannerlordCheats_v{Assembly.GetExecutingAssembly().GetName().Version}";

        public override string FolderName => "Cheats";

        public override string DisplayName
        {
            get
            {
                try { return L10N.GetText(ModName); }
                catch { return "Cheats"; }
            }
        }

        #endregion Base

        #region Hotkeys

        [LocalizedSettingPropertyGroup(HotkeysGroupName)]
        [LocalizedSettingPropertyBool(nameof(EnableHotkeys))]
        public bool EnableHotkeys { get; set; } = false;

        #endregion Hotkeys

        #region Map

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(MapSpeedFactor), minValue: 1, maxValue: 100)]
        public float MapSpeedFactor { get; set; } = 1;

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(MapVisibilityFactor), minValue: 1, maxValue: 10)]
        public float MapVisibilityFactor { get; set; } = 1;

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyPercent(nameof(NpcMapSpeedPercentage))]
        public int NpcMapSpeedPercentage { get; set; } = 100;

        [LocalizedSettingPropertyGroup(MapGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyInvisibleOnMap))]
        public bool PartyInvisibleOnMap { get; set; } = false;

        #endregion Map

        #region Combat

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(Invincible))]
        public bool Invincible { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(PartyInvincible))]
        public bool PartyInvincible { get; set; } = false;

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
        [LocalizedSettingPropertyFloatingInteger(nameof(RenownRewardMultiplier), minValue: 1, maxValue: 1000)]
        public float RenownRewardMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(InfluenceRewardMultiplier), minValue: 1, maxValue: 1000)]
        public float InfluenceRewardMultiplier { get; set; } = 1;

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
        [LocalizedSettingPropertyInteger(nameof(BanditHideoutTroopLimit), minValue: 0, maxValue: 100)]
        public int BanditHideoutTroopLimit { get; set; } = 0;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(AlwaysCrushThroughShields))]
        public bool AlwaysCrushThroughShields { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyPercent(nameof(HealthRegeneration))]
        public int HealthRegeneration { get; set; } = 0;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyBool(nameof(InfiniteAmmo))]
        public bool InfiniteAmmo { get; set; } = false;

        [LocalizedSettingPropertyGroup(CombatGroupName)]
        [LocalizedSettingPropertyInteger(nameof(DamageMultiplier), minValue: 1, maxValue: 100)]
        public int DamageMultiplier { get; set; } = 1;

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
        [LocalizedSettingPropertyBool(nameof(NoFoodConsumption))]
        public bool NoFoodConsumption { get; set; } = false;

        [LocalizedSettingPropertyGroup(PartyGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoTroopWages))]
        public bool NoTroopWages { get; set; } = false;

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
        [LocalizedSettingPropertyFloatingInteger(nameof(PartyHealingMultiplier), minValue: 1, maxValue: 100)]
        public float PartyHealingMultiplier { get; set; } = 1;

        #endregion

        #region Clan

        [LocalizedSettingPropertyGroup(ClanGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraCompanionLimit), minValue: 0, maxValue: 100)]
        public int ExtraCompanionLimit { get; set; } = 0;

        [LocalizedSettingPropertyGroup(ClanGroupName)]
        [LocalizedSettingPropertyInteger(nameof(ExtraClanPartyLimit), minValue: 0, maxValue: 100)]
        public int ExtraClanPartyLimit { get; set; } = 0;

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
        [LocalizedSettingPropertyBool(nameof(ForceKingdomDecision))]
        public bool ForceKingdomDecision { get; set; } = false;

        [LocalizedSettingPropertyGroup(KingdomGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoRelationshipLossOnDecision))]
        public bool NoRelationshipLossOnDecision { get; set; } = false;

        #endregion Kingdom

        #region Experience

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(ExperienceMultiplier), minValue: 1, maxValue: 1000)]
        public float ExperienceMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(LearningRateMultiplier), minValue: 1, maxValue: 1000)]
        public float LearningRateMultiplier { get; set; } = 1;

        [LocalizedSettingPropertyGroup(ExperienceGroupName)]
        [LocalizedSettingPropertyInteger(nameof(TroopExperienceMultiplier), minValue: 1, maxValue: 1000)]
        public int TroopExperienceMultiplier { get; set; } = 1;

        #endregion Experience

        #region Sieges

        [LocalizedSettingPropertyGroup(SiegesGroupName)]
        [LocalizedSettingPropertyFloatingInteger(nameof(SiegeBuildingSpeedMultiplier), minValue: 1, maxValue: 1000)]
        public float SiegeBuildingSpeedMultiplier { get; set; } = 1;
        
        [LocalizedSettingPropertyGroup(SiegesGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoEnemySiegeBuilding))]
        public bool NoEnemySiegeBuilding { get; set; } = false;

        #endregion Sieges

        #region Army

        [LocalizedSettingPropertyGroup(ArmyGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoArmyCohesionLoss))]
        public bool NoArmyCohesionLoss { get; set; } = false;

        [LocalizedSettingPropertyGroup(ArmyGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoArmyFoodConsumption))]
        public bool NoArmyFoodConsumption { get; set; } = false;

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

        #endregion Settlements

        #region Smithing

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoSmithingEnergyCost))]
        public bool NoSmithingEnergyCost { get; set; } = false;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyBool(nameof(UnlockAllParts))]
        public bool UnlockAllParts { get; set; } = false;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoSmithingDifficulty))]
        public bool NoSmithingDifficulty { get; set; } = false;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyBool(nameof(NoSmithingCost))]
        public bool NoSmithingCost { get; set; } = false;

        [LocalizedSettingPropertyGroup(SmithingGroupName)]
        [LocalizedSettingPropertyInteger(nameof(CreaftedWeaponValuesBonus), minValue: 0, maxValue: 200)]
        public int CreaftedWeaponValuesBonus { get; set; } = 0;

        #endregion Smithing
    }
}
