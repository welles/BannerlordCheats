namespace BannerlordCheats.Settings
{
    public static partial class SettingsManager
    {
        public static class Default
        {
            #region Global

            public const bool EnableHotkeys = false;

            public const bool EnableHotkeyTips = false;

            #endregion Global

            #region Map

            public const float MapSpeedMultiplier = 1.0f;

            public const float MapVisibilityMultiplier = 1.0f;

            public const float NpcMapSpeedPercentage = 100.0f;

            public const bool PartyInvisibleOnMap = false;

            #endregion Map

            #region Combat - Player

            public const float DamageTakenPercentage = 100.0f;

            public const bool Invincible = false;

            public const bool PlayerHorseInvincible = false;

            public const bool OneHitKill = false;

            public const bool AlwaysCrushThroughShields = false;

            public const bool SliceThroughEveryone = false;

            public const float HealthRegeneration = 0.0f;

            public const bool InfiniteAmmo = false;

            public const float DamageMultiplier = 1.0f;

            public const bool AlwaysKnockDown = false;

            public const bool NeverKnockedBackByAttacks = false;

            public const bool NoStuckArrows = false;

            public const bool InstantCrossbowReload = false;

            #endregion Combat - Player

            #region Combat - Party

            public const KnockoutOrKilled PartyKnockoutOrKilled = KnockoutOrKilled.Default;

            public const KnockoutOrKilled CompanionsKnockoutOrKilled = KnockoutOrKilled.Default;

            public const bool PartyInvincible = false;

            public const bool PartyHeroesInvincible = false;

            public const float PartyDamageTakenPercentage = 100.0f;

            public const bool PartyOneHitKill = false;

            public const bool PartyOnlyKnockout = false;

            public const bool NoRunningAway = false;

            public const float PartyHealthRegeneration = 0.0f;

            public const bool PartyInfiniteAmmo = false;

            public const float PartyDamageMultiplier = 1.0f;

            public const bool NoFriendlyFire = false;

            public const float CompanionDeathPercentage = 100.0f;

            #endregion Combat - Party

            #region Combat - Allies

            public const float FriendlyLordCombatDeathPercentage = 100.0f;

            #endregion Combat - Allies

            #region Combat - Enemies

            public const bool EnemyOnlyKnockout = false;

            public const bool EnemiesNoRunningAway = false;

            public const float EnemyDamagePercentage = 100.0f;

            public const float EnemyLordCombatDeathPercentage = 100.0f;

            public const float EnemyLordCombatDeathChanceMultiplier = 1.0f;

            #endregion Combat - Enemies

            #region Combat - Misc

            public const float RenownRewardMultiplier = 1.0f;

            public const float InfluenceRewardMultiplier = 1.0f;

            public const bool AlwaysWinBattleSimulation = false;

            public const bool NoTroopSacrifice = false;

            public const int BanditHideoutTroopLimit = 0;

            public const float CombatZoomMultiplier = 1.0f;

            #endregion Combat - Misc

            #region Inventory

            public const int ExtraInventoryCapacity = 0;

            public const bool NativeItemSpawning = false;

            #endregion Inventory

            #region Party

            public const int ExtraPartyMemberSize = 0;

            public const int ExtraPartyPrisonerSize = 0;

            public const int ExtraPartyMorale = 0;

            public const bool InstantEscape = false;

            public const float FoodConsumptionPercentage = 100.0f;

            public const float TroopWagesPercentage = 100.0f;

            public const bool FreeTroopUpgrades = false;

            public const bool FreeCompanionHiring = false;

            public const bool InstantPrisonerRecruitment = false;

            public const bool NoPrisonerEscape = false;

            public const float PartyHealingMultiplier = 1.0f;

            #endregion

            #region Clan

            public const int ExtraCompanionLimit = 0;

            public const int ExtraClanPartyLimit = 0;

            public const int ExtraClanPartySize = 0;

            #endregion Clan

            #region Characters

            public const bool PerfectRelationships = false;

            public const bool NeverDieOfOldAge = false;

            public const bool BarterOfferAlwaysAccepted = false;

            public const bool NoBarterCooldown = false;

            public const bool ConversationAlwaysSuccessful = false;

            public const bool PerfectAttraction = false;

            public const bool AllowSameSexMarriage = false;

            public const float PregnancyChanceMultiplier = 1.0f;

            public const int AdjustPregnancyDuration = 36;

            #endregion Characters

            #region Kingdom

            public const float KingdomDecisionWeightMultiplier = 1.0f;

            public const bool NoRelationshipLossOnDecision = false;

            public const bool NoCrimeRatingForCrimes = false;

            public const float DecisionOverrideInfluenceCostPercentage = 100.0f;

            #endregion Kingdom

            #region Experience

            public const float ExperienceMultiplier = 1.0f;

            public const float CompanionExperienceMultiplier = 1.0f;

            public const float LearningRateMultiplier = 1.0f;

            public const float CompanionLearningRateMultiplier = 1.0f;

            public const float LearningLimitMultiplier = 1.0f;

            public const float TroopExperienceMultiplier = 1.0f;

            public const bool FreeFocusPointAssignment = false;

            #endregion Experience

            #region Sieges

            public const float SiegeBuildingSpeedMultiplier = 1.0f;

            public const float EnemySiegeBuildingSpeedPercentage = 100.0f;

            #endregion Sieges

            #region Army

            public const float FactionArmyCohesionLossPercentage = 100.0f;

            public const float ArmyCohesionLossPercentage = 100.0f;

            public const float ArmyFoodConsumptionPercentage = 100.0f;

            #endregion Army

            #region Settlements

            public const bool DisguiseAlwaysWorks = false;

            public const bool FreeTroopRecruitment = false;

            public const float ItemTradingCostPercentage = 100.0f;

            public const float SellingPriceMultiplier = 1.0f;

            public const float TournamentMaximumBetMultiplier = 1.0f;

            public const int DailyFoodBonus = 0;

            public const int DailyGarrisonBonus = 0;

            public const int DailyMilitiaBonus = 0;

            public const int DailyProsperityBonus = 0;

            public const int DailyLoyaltyBonus = 0;

            public const int DailySecurityBonus = 0;

            public const int DailyHearthsBonus = 0;

            public const float GarrisonWagesPercentage = 100.0f;

            public const bool NeverRequireCivilianEquipment = false;

            public const float ConstructionPowerMultiplier = 1.0f;

            public const bool NoBribeToEnterKeep = false;

            public const bool SettlementsNeverRebel = false;

            #endregion Settlements

            #region Smithing

            public const float SmithingEnergyCostPercentage = 100.0f;

            public const bool UnlockAllParts = false;

            public const float SmithingDifficultyPercentage = 100.0f;

            public const float SmithingCostPercentage = 100.0f;

            public const int CraftedWeaponHandlingBonus = 0;

            public const int CraftedWeaponSwingDamageBonus = 0;

            public const int CraftedWeaponSwingSpeedBonus = 0;

            public const int CraftedWeaponThrustDamageBonus = 0;

            public const int CraftedWeaponThrustSpeedBonus = 0;

            #endregion Smithing

            #region Workshops

            public const float WorkshopBuyingCostPercentage = 100.0f;

            public const float WorkshopDailyExpensePercentage = 100.0f;

            public const float WorkshopUpgradeCostPercentage = 100.0f;

            public const float WorkshopSellingCostMultiplier = 1.0f;

            public const bool EveryoneBuysWorkshops = false;

            #endregion Workshops
        }
    }
}
