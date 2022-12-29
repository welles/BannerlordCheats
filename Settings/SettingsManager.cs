using System;
using BannerlordCheats.Extensions;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace BannerlordCheats.Settings
{
    public static partial class SettingsManager
    {
        private static bool IsPerCampaignInstanceLoaded => BannerlordCheatsPerCampaignSettings.Instance != null;

        private static BannerlordCheatsGlobalSettings GlobalInstance =>
            BannerlordCheatsGlobalSettings.Instance ?? throw new InvalidOperationException("Should have checked if global instance is loaded!");

        private static BannerlordCheatsPerCampaignSettings PerCampaignInstance =>
            BannerlordCheatsPerCampaignSettings.Instance ?? throw new InvalidOperationException("Should have checked if per-campaign instance is loaded!");

        #region Global

        public static CheatValue<bool> EnableHotkeys =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.EnableHotkeys != Default.EnableHotkeys
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.EnableHotkeys)
                : SettingsManager.GlobalInstance.EnableHotkeys != Default.EnableHotkeys
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.EnableHotkeys)
                    : new CheatValue<bool>(false, Default.EnableHotkeys);

        public static CheatValue<bool> EnableHotkeyTips =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.EnableHotkeyTips != Default.EnableHotkeyTips
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.EnableHotkeyTips)
                : SettingsManager.GlobalInstance.EnableHotkeyTips != Default.EnableHotkeyTips
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.EnableHotkeyTips)
                    : new CheatValue<bool>(false, Default.EnableHotkeyTips);

        #endregion Global

        #region Map

        public static CheatValue<float> MapSpeedMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.MapSpeedMultiplier != Default.MapSpeedMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.MapSpeedMultiplier)
                : SettingsManager.GlobalInstance.MapSpeedMultiplier != Default.MapSpeedMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.MapSpeedMultiplier)
                    : new CheatValue<float>(false, Default.MapSpeedMultiplier);

        public static CheatValue<float> MapVisibilityMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.MapVisibilityMultiplier != Default.MapVisibilityMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.MapVisibilityMultiplier)
                : SettingsManager.GlobalInstance.MapVisibilityMultiplier != Default.MapVisibilityMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.MapVisibilityMultiplier)
                    : new CheatValue<float>(false, Default.MapVisibilityMultiplier);

        public static CheatValue<float> NpcMapSpeedPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.NpcMapSpeedPercentage != Default.NpcMapSpeedPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.NpcMapSpeedPercentage)
                : SettingsManager.GlobalInstance.NpcMapSpeedPercentage != Default.NpcMapSpeedPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.NpcMapSpeedPercentage)
                    : new CheatValue<float>(false, Default.NpcMapSpeedPercentage);

        public static CheatValue<bool> PartyInvisibleOnMap =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.PartyInvisibleOnMap != Default.PartyInvisibleOnMap
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.PartyInvisibleOnMap)
                : SettingsManager.GlobalInstance.PartyInvisibleOnMap != Default.PartyInvisibleOnMap
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PartyInvisibleOnMap)
                    : new CheatValue<bool>(false, Default.PartyInvisibleOnMap);

        public static CheatValue<bool> CaravansInvisibleOnMap =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.CaravansInvisibleOnMap != Default.CaravansInvisibleOnMap
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.CaravansInvisibleOnMap)
                : SettingsManager.GlobalInstance.CaravansInvisibleOnMap != Default.CaravansInvisibleOnMap
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.CaravansInvisibleOnMap)
                    : new CheatValue<bool>(false, Default.CaravansInvisibleOnMap);

        #endregion Map

        #region Combat - Player

        public static CheatValue<float> DamageTakenPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.DamageTakenPercentage != Default.DamageTakenPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.DamageTakenPercentage)
                : SettingsManager.GlobalInstance.DamageTakenPercentage != Default.DamageTakenPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.DamageTakenPercentage)
                    : new CheatValue<float>(false, Default.DamageTakenPercentage);

        public static CheatValue<bool> Invincible =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.Invincible != Default.Invincible
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.Invincible)
                : SettingsManager.GlobalInstance.Invincible != Default.Invincible
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.Invincible)
                    : new CheatValue<bool>(false, Default.Invincible);

        public static CheatValue<bool> PlayerHorseInvincible =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.PlayerHorseInvincible != Default.PlayerHorseInvincible
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.PlayerHorseInvincible)
                : SettingsManager.GlobalInstance.PlayerHorseInvincible != Default.PlayerHorseInvincible
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PlayerHorseInvincible)
                    : new CheatValue<bool>(false, Default.PlayerHorseInvincible);

        public static CheatValue<bool> OneHitKill =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.OneHitKill != Default.OneHitKill
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.OneHitKill)
                : SettingsManager.GlobalInstance.OneHitKill != Default.OneHitKill
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.OneHitKill)
                    : new CheatValue<bool>(false, Default.OneHitKill);

        public static CheatValue<bool> AlwaysCrushThroughShields =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.AlwaysCrushThroughShields != Default.AlwaysCrushThroughShields
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.AlwaysCrushThroughShields)
                : SettingsManager.GlobalInstance.AlwaysCrushThroughShields != Default.AlwaysCrushThroughShields
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.AlwaysCrushThroughShields)
                    : new CheatValue<bool>(false, Default.AlwaysCrushThroughShields);

        public static CheatValue<bool> SliceThroughEveryone =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.SliceThroughEveryone != Default.SliceThroughEveryone
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.SliceThroughEveryone)
                : SettingsManager.GlobalInstance.SliceThroughEveryone != Default.SliceThroughEveryone
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.SliceThroughEveryone)
                    : new CheatValue<bool>(false, Default.SliceThroughEveryone);

        public static CheatValue<float> HealthRegeneration =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.HealthRegeneration != Default.HealthRegeneration
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.HealthRegeneration)
                : SettingsManager.GlobalInstance.HealthRegeneration != Default.HealthRegeneration
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.HealthRegeneration)
                    : new CheatValue<float>(false, Default.HealthRegeneration);

        public static CheatValue<bool> InfiniteAmmo =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.InfiniteAmmo != Default.InfiniteAmmo
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.InfiniteAmmo)
                : SettingsManager.GlobalInstance.InfiniteAmmo != Default.InfiniteAmmo
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.InfiniteAmmo)
                    : new CheatValue<bool>(false, Default.InfiniteAmmo);

        public static CheatValue<float> DamageMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.DamageMultiplier != Default.DamageMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.DamageMultiplier)
                : SettingsManager.GlobalInstance.DamageMultiplier != Default.DamageMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.DamageMultiplier)
                    : new CheatValue<float>(false, Default.DamageMultiplier);

        public static CheatValue<bool> AlwaysKnockDown =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.AlwaysKnockDown != Default.AlwaysKnockDown
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.AlwaysKnockDown)
                : SettingsManager.GlobalInstance.AlwaysKnockDown != Default.AlwaysKnockDown
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.AlwaysKnockDown)
                    : new CheatValue<bool>(false, Default.AlwaysKnockDown);

        public static CheatValue<bool> NeverKnockedBackByAttacks =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.NeverKnockedBackByAttacks != Default.NeverKnockedBackByAttacks
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NeverKnockedBackByAttacks)
                : SettingsManager.GlobalInstance.NeverKnockedBackByAttacks != Default.NeverKnockedBackByAttacks
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NeverKnockedBackByAttacks)
                    : new CheatValue<bool>(false, Default.NeverKnockedBackByAttacks);

        public static CheatValue<bool> NoStuckArrows =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.NoStuckArrows != Default.NoStuckArrows
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NoStuckArrows)
                : SettingsManager.GlobalInstance.NoStuckArrows != Default.NoStuckArrows
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoStuckArrows)
                    : new CheatValue<bool>(false, Default.NoStuckArrows);

        public static CheatValue<bool> InstantCrossbowReload =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.InstantCrossbowReload != Default.InstantCrossbowReload
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.InstantCrossbowReload)
                : SettingsManager.GlobalInstance.InstantCrossbowReload != Default.InstantCrossbowReload
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.InstantCrossbowReload)
                    : new CheatValue<bool>(false, Default.InstantCrossbowReload);

        #endregion Combat - Player

        #region Combat - Party

        public static CheatValue<KnockoutOrKilled> PartyKnockoutOrKilled =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.PartyKnockoutOrKilled.GetValue() != Default.PartyKnockoutOrKilled
                ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.PerCampaignInstance.PartyKnockoutOrKilled.GetValue())
                : SettingsManager.GlobalInstance.PartyKnockoutOrKilled.GetValue() != Default.PartyKnockoutOrKilled
                    ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.GlobalInstance.PartyKnockoutOrKilled.GetValue())
                    : new CheatValue<KnockoutOrKilled>(false, Default.PartyKnockoutOrKilled);

        public static CheatValue<KnockoutOrKilled> CompanionsKnockoutOrKilled =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.CompanionsKnockoutOrKilled.GetValue() != Default.CompanionsKnockoutOrKilled
                ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.PerCampaignInstance.CompanionsKnockoutOrKilled.GetValue())
                : SettingsManager.GlobalInstance.CompanionsKnockoutOrKilled.GetValue() != Default.CompanionsKnockoutOrKilled
                    ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.GlobalInstance.CompanionsKnockoutOrKilled.GetValue())
                    : new CheatValue<KnockoutOrKilled>(false, Default.CompanionsKnockoutOrKilled);

        public static CheatValue<bool> PartyInvincible =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.PartyInvincible != Default.PartyInvincible
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.PartyInvincible)
                : SettingsManager.GlobalInstance.PartyInvincible != Default.PartyInvincible
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PartyInvincible)
                    : new CheatValue<bool>(false, Default.PartyInvincible);

        public static CheatValue<bool> PartyHeroesInvincible =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.PartyHeroesInvincible != Default.PartyHeroesInvincible
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.PartyHeroesInvincible)
                : SettingsManager.GlobalInstance.PartyHeroesInvincible != Default.PartyHeroesInvincible
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PartyHeroesInvincible)
                    : new CheatValue<bool>(false, Default.PartyHeroesInvincible);

        public static CheatValue<float> PartyDamageTakenPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.PartyDamageTakenPercentage != Default.PartyDamageTakenPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.PartyDamageTakenPercentage)
                : SettingsManager.GlobalInstance.PartyDamageTakenPercentage != Default.PartyDamageTakenPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.PartyDamageTakenPercentage)
                    : new CheatValue<float>(false, Default.PartyDamageTakenPercentage);

        public static CheatValue<bool> PartyOneHitKill =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.PartyOneHitKill != Default.PartyOneHitKill
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.PartyOneHitKill)
                : SettingsManager.GlobalInstance.PartyOneHitKill != Default.PartyOneHitKill
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PartyOneHitKill)
                    : new CheatValue<bool>(false, Default.PartyOneHitKill);

        public static CheatValue<bool> NoRunningAway =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.NoRunningAway != Default.NoRunningAway
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NoRunningAway)
                : SettingsManager.GlobalInstance.NoRunningAway != Default.NoRunningAway
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoRunningAway)
                    : new CheatValue<bool>(false, Default.NoRunningAway);

        public static CheatValue<float> PartyHealthRegeneration =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.PartyHealthRegeneration != Default.PartyHealthRegeneration
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.PartyHealthRegeneration)
                : SettingsManager.GlobalInstance.PartyHealthRegeneration != Default.PartyHealthRegeneration
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.PartyHealthRegeneration)
                    : new CheatValue<float>(false, Default.PartyHealthRegeneration);

        public static CheatValue<bool> PartyInfiniteAmmo =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.PartyInfiniteAmmo != Default.PartyInfiniteAmmo
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.PartyInfiniteAmmo)
                : SettingsManager.GlobalInstance.PartyInfiniteAmmo != Default.PartyInfiniteAmmo
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PartyInfiniteAmmo)
                    : new CheatValue<bool>(false, Default.PartyInfiniteAmmo);

        public static CheatValue<float> PartyDamageMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.PartyDamageMultiplier != Default.PartyDamageMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.PartyDamageMultiplier)
                : SettingsManager.GlobalInstance.PartyDamageMultiplier != Default.PartyDamageMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.PartyDamageMultiplier)
                    : new CheatValue<float>(false, Default.PartyDamageMultiplier);

        public static CheatValue<bool> NoFriendlyFire =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.NoFriendlyFire != Default.NoFriendlyFire
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NoFriendlyFire)
                : SettingsManager.GlobalInstance.NoFriendlyFire != Default.NoFriendlyFire
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoFriendlyFire)
                    : new CheatValue<bool>(false, Default.NoFriendlyFire);

        #endregion Combat - Party

        #region Combat - Allies

        public static CheatValue<KnockoutOrKilled> FriendlyLordsKnockoutOrKilled =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.FriendlyLordsKnockoutOrKilled.GetValue() != Default.FriendlyLordsKnockoutOrKilled
                ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.PerCampaignInstance.FriendlyLordsKnockoutOrKilled.GetValue())
                : SettingsManager.GlobalInstance.FriendlyLordsKnockoutOrKilled.GetValue() != Default.FriendlyLordsKnockoutOrKilled
                    ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.GlobalInstance.FriendlyLordsKnockoutOrKilled.GetValue())
                    : new CheatValue<KnockoutOrKilled>(false, Default.FriendlyLordsKnockoutOrKilled);

        #endregion Combat - Allies

        #region Combat - Enemies

        public static CheatValue<KnockoutOrKilled> EnemyLordsKnockoutOrKilled =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.EnemyLordsKnockoutOrKilled.GetValue() != Default.EnemyLordsKnockoutOrKilled
                ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.PerCampaignInstance.EnemyLordsKnockoutOrKilled.GetValue())
                : SettingsManager.GlobalInstance.EnemyLordsKnockoutOrKilled.GetValue() != Default.EnemyLordsKnockoutOrKilled
                    ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.GlobalInstance.EnemyLordsKnockoutOrKilled.GetValue())
                    : new CheatValue<KnockoutOrKilled>(false, Default.EnemyLordsKnockoutOrKilled);

        public static CheatValue<KnockoutOrKilled> EnemyTroopsKnockoutOrKilled =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.EnemyTroopsKnockoutOrKilled.GetValue() != Default.EnemyTroopsKnockoutOrKilled
                ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.PerCampaignInstance.EnemyTroopsKnockoutOrKilled.GetValue())
                : SettingsManager.GlobalInstance.EnemyTroopsKnockoutOrKilled.GetValue() != Default.EnemyTroopsKnockoutOrKilled
                    ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.GlobalInstance.EnemyTroopsKnockoutOrKilled.GetValue())
                    : new CheatValue<KnockoutOrKilled>(false, Default.EnemyTroopsKnockoutOrKilled);

        public static CheatValue<bool> EnemiesNoRunningAway =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.EnemiesNoRunningAway != Default.EnemiesNoRunningAway
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.EnemiesNoRunningAway)
                : SettingsManager.GlobalInstance.EnemiesNoRunningAway != Default.EnemiesNoRunningAway
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.EnemiesNoRunningAway)
                    : new CheatValue<bool>(false, Default.EnemiesNoRunningAway);

        public static CheatValue<float> EnemyDamagePercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.EnemyDamagePercentage != Default.EnemyDamagePercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.EnemyDamagePercentage)
                : SettingsManager.GlobalInstance.EnemyDamagePercentage != Default.EnemyDamagePercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.EnemyDamagePercentage)
                    : new CheatValue<float>(false, Default.EnemyDamagePercentage);

        #endregion Combat - Enemies

        #region Combat - Misc

        public static CheatValue<float> RenownRewardMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.RenownRewardMultiplier != Default.RenownRewardMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.RenownRewardMultiplier)
                : SettingsManager.GlobalInstance.RenownRewardMultiplier != Default.RenownRewardMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.RenownRewardMultiplier)
                    : new CheatValue<float>(false, Default.RenownRewardMultiplier);

        public static CheatValue<float> InfluenceRewardMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.InfluenceRewardMultiplier != Default.InfluenceRewardMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.InfluenceRewardMultiplier)
                : SettingsManager.GlobalInstance.InfluenceRewardMultiplier != Default.InfluenceRewardMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.InfluenceRewardMultiplier)
                    : new CheatValue<float>(false, Default.InfluenceRewardMultiplier);

        public static CheatValue<bool> AlwaysWinBattleSimulation =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.AlwaysWinBattleSimulation != Default.AlwaysWinBattleSimulation
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.AlwaysWinBattleSimulation)
                : SettingsManager.GlobalInstance.AlwaysWinBattleSimulation != Default.AlwaysWinBattleSimulation
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.AlwaysWinBattleSimulation)
                    : new CheatValue<bool>(false, Default.AlwaysWinBattleSimulation);

        public static CheatValue<bool> NoTroopSacrifice =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.NoTroopSacrifice != Default.NoTroopSacrifice
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NoTroopSacrifice)
                : SettingsManager.GlobalInstance.NoTroopSacrifice != Default.NoTroopSacrifice
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoTroopSacrifice)
                    : new CheatValue<bool>(false, Default.NoTroopSacrifice);

        public static CheatValue<int> BanditHideoutTroopLimit =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.BanditHideoutTroopLimit != Default.BanditHideoutTroopLimit
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.BanditHideoutTroopLimit)
                : SettingsManager.GlobalInstance.BanditHideoutTroopLimit != Default.BanditHideoutTroopLimit
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.BanditHideoutTroopLimit)
                    : new CheatValue<int>(false, Default.BanditHideoutTroopLimit);

        public static CheatValue<float> CombatZoomMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.CombatZoomMultiplier != Default.CombatZoomMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.CombatZoomMultiplier)
                : SettingsManager.GlobalInstance.CombatZoomMultiplier != Default.CombatZoomMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.CombatZoomMultiplier)
                    : new CheatValue<float>(false, Default.CombatZoomMultiplier);

        #endregion Combat - Misc

        #region Inventory

        public static CheatValue<int> ExtraInventoryCapacity =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.ExtraInventoryCapacity != Default.ExtraInventoryCapacity
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.ExtraInventoryCapacity)
                : SettingsManager.GlobalInstance.ExtraInventoryCapacity != Default.ExtraInventoryCapacity
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraInventoryCapacity)
                    : new CheatValue<int>(false, Default.ExtraInventoryCapacity);

        public static CheatValue<bool> NativeItemSpawning =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.NativeItemSpawning != Default.NativeItemSpawning
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NativeItemSpawning)
                : SettingsManager.GlobalInstance.NativeItemSpawning != Default.NativeItemSpawning
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NativeItemSpawning)
                    : new CheatValue<bool>(false, Default.NativeItemSpawning);

        #endregion Inventory

        #region Party

        public static CheatValue<int> ExtraPartyMemberSize =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.ExtraPartyMemberSize != Default.ExtraPartyMemberSize
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.ExtraPartyMemberSize)
                : SettingsManager.GlobalInstance.ExtraPartyMemberSize != Default.ExtraPartyMemberSize
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraPartyMemberSize)
                    : new CheatValue<int>(false, Default.ExtraPartyMemberSize);

        public static CheatValue<int> ExtraPartyPrisonerSize =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.ExtraPartyPrisonerSize != Default.ExtraPartyPrisonerSize
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.ExtraPartyPrisonerSize)
                : SettingsManager.GlobalInstance.ExtraPartyPrisonerSize != Default.ExtraPartyPrisonerSize
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraPartyPrisonerSize)
                    : new CheatValue<int>(false, Default.ExtraPartyPrisonerSize);

        public static CheatValue<int> ExtraPartyMorale =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.ExtraPartyMorale != Default.ExtraPartyMorale
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.ExtraPartyMorale)
                : SettingsManager.GlobalInstance.ExtraPartyMorale != Default.ExtraPartyMorale
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraPartyMorale)
                    : new CheatValue<int>(false, Default.ExtraPartyMorale);

        public static CheatValue<bool> InstantEscape =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.InstantEscape != Default.InstantEscape
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.InstantEscape)
                : SettingsManager.GlobalInstance.InstantEscape != Default.InstantEscape
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.InstantEscape)
                    : new CheatValue<bool>(false, Default.InstantEscape);

        public static CheatValue<float> FoodConsumptionPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.FoodConsumptionPercentage != Default.FoodConsumptionPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.FoodConsumptionPercentage)
                : SettingsManager.GlobalInstance.FoodConsumptionPercentage != Default.FoodConsumptionPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.FoodConsumptionPercentage)
                    : new CheatValue<float>(false, Default.FoodConsumptionPercentage);

        public static CheatValue<float> TroopWagesPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.TroopWagesPercentage != Default.TroopWagesPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.TroopWagesPercentage)
                : SettingsManager.GlobalInstance.TroopWagesPercentage != Default.TroopWagesPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.TroopWagesPercentage)
                    : new CheatValue<float>(false, Default.TroopWagesPercentage);

        public static CheatValue<bool> FreeTroopUpgrades =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.FreeTroopUpgrades != Default.FreeTroopUpgrades
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.FreeTroopUpgrades)
                : SettingsManager.GlobalInstance.FreeTroopUpgrades != Default.FreeTroopUpgrades
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.FreeTroopUpgrades)
                    : new CheatValue<bool>(false, Default.FreeTroopUpgrades);

        public static CheatValue<bool> FreeCompanionHiring =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.FreeCompanionHiring != Default.FreeCompanionHiring
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.FreeCompanionHiring)
                : SettingsManager.GlobalInstance.FreeCompanionHiring != Default.FreeCompanionHiring
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.FreeCompanionHiring)
                    : new CheatValue<bool>(false, Default.FreeCompanionHiring);

        public static CheatValue<bool> InstantPrisonerRecruitment =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.InstantPrisonerRecruitment != Default.InstantPrisonerRecruitment
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.InstantPrisonerRecruitment)
                : SettingsManager.GlobalInstance.InstantPrisonerRecruitment != Default.InstantPrisonerRecruitment
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.InstantPrisonerRecruitment)
                    : new CheatValue<bool>(false, Default.InstantPrisonerRecruitment);

        public static CheatValue<bool> NoPrisonerEscape =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.NoPrisonerEscape != Default.NoPrisonerEscape
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NoPrisonerEscape)
                : SettingsManager.GlobalInstance.NoPrisonerEscape != Default.NoPrisonerEscape
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoPrisonerEscape)
                    : new CheatValue<bool>(false, Default.NoPrisonerEscape);

        public static CheatValue<float> PartyHealingMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.PartyHealingMultiplier != Default.PartyHealingMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.PartyHealingMultiplier)
                : SettingsManager.GlobalInstance.PartyHealingMultiplier != Default.PartyHealingMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.PartyHealingMultiplier)
                    : new CheatValue<float>(false, Default.PartyHealingMultiplier);

        #endregion

        #region Clan

        public static CheatValue<int> ExtraCompanionLimit =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.ExtraCompanionLimit != Default.ExtraCompanionLimit
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.ExtraCompanionLimit)
                : SettingsManager.GlobalInstance.ExtraCompanionLimit != Default.ExtraCompanionLimit
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraCompanionLimit)
                    : new CheatValue<int>(false, Default.ExtraCompanionLimit);

        public static CheatValue<int> ExtraClanPartyLimit =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.ExtraClanPartyLimit != Default.ExtraClanPartyLimit
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.ExtraClanPartyLimit)
                : SettingsManager.GlobalInstance.ExtraClanPartyLimit != Default.ExtraClanPartyLimit
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraClanPartyLimit)
                    : new CheatValue<int>(false, Default.ExtraClanPartyLimit);

        public static CheatValue<int> ExtraClanPartySize =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.ExtraClanPartySize != Default.ExtraClanPartySize
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.ExtraClanPartySize)
                : SettingsManager.GlobalInstance.ExtraClanPartySize != Default.ExtraClanPartySize
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraClanPartySize)
                    : new CheatValue<int>(false, Default.ExtraClanPartySize);

        #endregion Clan

        #region Characters

        public static CheatValue<float> RelationGainAfterBattleMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.RelationGainAfterBattleMultiplier != Default.RelationGainAfterBattleMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.RelationGainAfterBattleMultiplier)
                : SettingsManager.GlobalInstance.RelationGainAfterBattleMultiplier != Default.RelationGainAfterBattleMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.RelationGainAfterBattleMultiplier)
                    : new CheatValue<float>(false, Default.RelationGainAfterBattleMultiplier);

        public static CheatValue<bool> PerfectRelationships =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.PerfectRelationships != Default.PerfectRelationships
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.PerfectRelationships)
                : SettingsManager.GlobalInstance.PerfectRelationships != Default.PerfectRelationships
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PerfectRelationships)
                    : new CheatValue<bool>(false, Default.PerfectRelationships);

        public static CheatValue<bool> NeverDieOfOldAge =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.NeverDieOfOldAge != Default.NeverDieOfOldAge
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NeverDieOfOldAge)
                : SettingsManager.GlobalInstance.NeverDieOfOldAge != Default.NeverDieOfOldAge
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NeverDieOfOldAge)
                    : new CheatValue<bool>(false, Default.NeverDieOfOldAge);

        public static CheatValue<bool> BarterOfferAlwaysAccepted =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.BarterOfferAlwaysAccepted != Default.BarterOfferAlwaysAccepted
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.BarterOfferAlwaysAccepted)
                : SettingsManager.GlobalInstance.BarterOfferAlwaysAccepted != Default.BarterOfferAlwaysAccepted
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.BarterOfferAlwaysAccepted)
                    : new CheatValue<bool>(false, Default.BarterOfferAlwaysAccepted);

        public static CheatValue<bool> NoBarterCooldown =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.NoBarterCooldown != Default.NoBarterCooldown
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NoBarterCooldown)
                : SettingsManager.GlobalInstance.NoBarterCooldown != Default.NoBarterCooldown
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoBarterCooldown)
                    : new CheatValue<bool>(false, Default.NoBarterCooldown);

        public static CheatValue<bool> ConversationAlwaysSuccessful =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.ConversationAlwaysSuccessful != Default.ConversationAlwaysSuccessful
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.ConversationAlwaysSuccessful)
                : SettingsManager.GlobalInstance.ConversationAlwaysSuccessful != Default.ConversationAlwaysSuccessful
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.ConversationAlwaysSuccessful)
                    : new CheatValue<bool>(false, Default.ConversationAlwaysSuccessful);

        public static CheatValue<bool> PerfectAttraction =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.PerfectAttraction != Default.PerfectAttraction
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.PerfectAttraction)
                : SettingsManager.GlobalInstance.PerfectAttraction != Default.PerfectAttraction
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PerfectAttraction)
                    : new CheatValue<bool>(false, Default.PerfectAttraction);

        public static CheatValue<bool> AllowSameSexMarriage =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.AllowSameSexMarriage != Default.AllowSameSexMarriage
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.AllowSameSexMarriage)
                : SettingsManager.GlobalInstance.AllowSameSexMarriage != Default.AllowSameSexMarriage
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.AllowSameSexMarriage)
                    : new CheatValue<bool>(false, Default.AllowSameSexMarriage);

        public static CheatValue<float> PregnancyChanceMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.PregnancyChanceMultiplier != Default.PregnancyChanceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.PregnancyChanceMultiplier)
                : SettingsManager.GlobalInstance.PregnancyChanceMultiplier != Default.PregnancyChanceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.PregnancyChanceMultiplier)
                    : new CheatValue<float>(false, Default.PregnancyChanceMultiplier);

        public static CheatValue<int> AdjustPregnancyDuration =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.AdjustPregnancyDuration != Default.AdjustPregnancyDuration
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.AdjustPregnancyDuration)
                : SettingsManager.GlobalInstance.AdjustPregnancyDuration != Default.AdjustPregnancyDuration
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.AdjustPregnancyDuration)
                    : new CheatValue<int>(false, Default.AdjustPregnancyDuration);

        #endregion Characters

        #region Kingdom

        public static CheatValue<float> KingdomDecisionWeightMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.KingdomDecisionWeightMultiplier != Default.KingdomDecisionWeightMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.KingdomDecisionWeightMultiplier)
                : SettingsManager.GlobalInstance.KingdomDecisionWeightMultiplier != Default.KingdomDecisionWeightMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.KingdomDecisionWeightMultiplier)
                    : new CheatValue<float>(false, Default.KingdomDecisionWeightMultiplier);

        public static CheatValue<bool> NoRelationshipLossOnDecision =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.NoRelationshipLossOnDecision != Default.NoRelationshipLossOnDecision
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NoRelationshipLossOnDecision)
                : SettingsManager.GlobalInstance.NoRelationshipLossOnDecision != Default.NoRelationshipLossOnDecision
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoRelationshipLossOnDecision)
                    : new CheatValue<bool>(false, Default.NoRelationshipLossOnDecision);

        public static CheatValue<bool> NoCrimeRatingForCrimes =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.NoCrimeRatingForCrimes != Default.NoCrimeRatingForCrimes
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NoCrimeRatingForCrimes)
                : SettingsManager.GlobalInstance.NoCrimeRatingForCrimes != Default.NoCrimeRatingForCrimes
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoCrimeRatingForCrimes)
                    : new CheatValue<bool>(false, Default.NoCrimeRatingForCrimes);

        public static CheatValue<float> DecisionOverrideInfluenceCostPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.DecisionOverrideInfluenceCostPercentage != Default.DecisionOverrideInfluenceCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.DecisionOverrideInfluenceCostPercentage)
                : SettingsManager.GlobalInstance.DecisionOverrideInfluenceCostPercentage != Default.DecisionOverrideInfluenceCostPercentage
                    ? new CheatValue<float>(true,
                        SettingsManager.GlobalInstance.DecisionOverrideInfluenceCostPercentage)
                    : new CheatValue<float>(false, Default.DecisionOverrideInfluenceCostPercentage);

        #endregion Kingdom

        #region Experience

        public static CheatValue<float> ExperienceMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.ExperienceMultiplier != Default.ExperienceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.ExperienceMultiplier)
                : SettingsManager.GlobalInstance.ExperienceMultiplier != Default.ExperienceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ExperienceMultiplier)
                    : new CheatValue<float>(false, Default.ExperienceMultiplier);

        public static CheatValue<float> CompanionExperienceMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.CompanionExperienceMultiplier != Default.CompanionExperienceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.CompanionExperienceMultiplier)
                : SettingsManager.GlobalInstance.CompanionExperienceMultiplier != Default.CompanionExperienceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.CompanionExperienceMultiplier)
                    : new CheatValue<float>(false, Default.CompanionExperienceMultiplier);

        public static CheatValue<float> ClanExperienceMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.ClanExperienceMultiplier != Default.ClanExperienceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.ClanExperienceMultiplier)
                : SettingsManager.GlobalInstance.ClanExperienceMultiplier != Default.ClanExperienceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ClanExperienceMultiplier)
                    : new CheatValue<float>(false, Default.ClanExperienceMultiplier);

        public static CheatValue<float> LearningRateMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.LearningRateMultiplier != Default.LearningRateMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.LearningRateMultiplier)
                : SettingsManager.GlobalInstance.LearningRateMultiplier != Default.LearningRateMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.LearningRateMultiplier)
                    : new CheatValue<float>(false, Default.LearningRateMultiplier);

        public static CheatValue<float> CompanionLearningRateMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.CompanionLearningRateMultiplier != Default.CompanionLearningRateMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.CompanionLearningRateMultiplier)
                : SettingsManager.GlobalInstance.CompanionLearningRateMultiplier != Default.CompanionLearningRateMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.CompanionLearningRateMultiplier)
                    : new CheatValue<float>(false, Default.CompanionLearningRateMultiplier);

        public static CheatValue<float> LearningLimitMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.LearningLimitMultiplier != Default.LearningLimitMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.LearningLimitMultiplier)
                : SettingsManager.GlobalInstance.LearningLimitMultiplier != Default.LearningLimitMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.LearningLimitMultiplier)
                    : new CheatValue<float>(false, Default.LearningLimitMultiplier);

        public static CheatValue<float> TroopExperienceMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.TroopExperienceMultiplier != Default.TroopExperienceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.TroopExperienceMultiplier)
                : SettingsManager.GlobalInstance.TroopExperienceMultiplier != Default.TroopExperienceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.TroopExperienceMultiplier)
                    : new CheatValue<float>(false, Default.TroopExperienceMultiplier);

        public static CheatValue<bool> FreeFocusPointAssignment =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.FreeFocusPointAssignment != Default.FreeFocusPointAssignment
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.FreeFocusPointAssignment)
                : SettingsManager.GlobalInstance.FreeFocusPointAssignment != Default.FreeFocusPointAssignment
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.FreeFocusPointAssignment)
                    : new CheatValue<bool>(false, Default.FreeFocusPointAssignment);

        #endregion Experience

        #region Sieges

        public static CheatValue<float> SiegeBuildingSpeedMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.SiegeBuildingSpeedMultiplier != Default.SiegeBuildingSpeedMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.SiegeBuildingSpeedMultiplier)
                : SettingsManager.GlobalInstance.SiegeBuildingSpeedMultiplier != Default.SiegeBuildingSpeedMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.SiegeBuildingSpeedMultiplier)
                    : new CheatValue<float>(false, Default.SiegeBuildingSpeedMultiplier);

        public static CheatValue<float> EnemySiegeBuildingSpeedPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.EnemySiegeBuildingSpeedPercentage != Default.EnemySiegeBuildingSpeedPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.EnemySiegeBuildingSpeedPercentage)
                : SettingsManager.GlobalInstance.EnemySiegeBuildingSpeedPercentage != Default.EnemySiegeBuildingSpeedPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.EnemySiegeBuildingSpeedPercentage)
                    : new CheatValue<float>(false, Default.EnemySiegeBuildingSpeedPercentage);

        #endregion Sieges

        #region Army

        public static CheatValue<float> FactionArmyCohesionLossPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.FactionArmyCohesionLossPercentage != Default.FactionArmyCohesionLossPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.FactionArmyCohesionLossPercentage)
                : SettingsManager.GlobalInstance.FactionArmyCohesionLossPercentage != Default.FactionArmyCohesionLossPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.FactionArmyCohesionLossPercentage)
                    : new CheatValue<float>(false, Default.FactionArmyCohesionLossPercentage);

        public static CheatValue<float> ArmyCohesionLossPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.ArmyCohesionLossPercentage != Default.ArmyCohesionLossPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.ArmyCohesionLossPercentage)
                : SettingsManager.GlobalInstance.ArmyCohesionLossPercentage != Default.ArmyCohesionLossPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ArmyCohesionLossPercentage)
                    : new CheatValue<float>(false, Default.ArmyCohesionLossPercentage);

        public static CheatValue<float> ArmyFoodConsumptionPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.ArmyFoodConsumptionPercentage != Default.ArmyFoodConsumptionPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.ArmyFoodConsumptionPercentage)
                : SettingsManager.GlobalInstance.ArmyFoodConsumptionPercentage != Default.ArmyFoodConsumptionPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ArmyFoodConsumptionPercentage)
                    : new CheatValue<float>(false, Default.ArmyFoodConsumptionPercentage);

        #endregion Army

        #region Settlements

        public static CheatValue<bool> VillagesNeverRaided =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.VillagesNeverRaided != Default.VillagesNeverRaided
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.VillagesNeverRaided)
                : SettingsManager.GlobalInstance.VillagesNeverRaided != Default.VillagesNeverRaided
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.VillagesNeverRaided)
                    : new CheatValue<bool>(false, Default.VillagesNeverRaided);

        public static CheatValue<bool> DisguiseAlwaysWorks =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.DisguiseAlwaysWorks != Default.DisguiseAlwaysWorks
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.DisguiseAlwaysWorks)
                : SettingsManager.GlobalInstance.DisguiseAlwaysWorks != Default.DisguiseAlwaysWorks
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.DisguiseAlwaysWorks)
                    : new CheatValue<bool>(false, Default.DisguiseAlwaysWorks);

        public static CheatValue<bool> FreeTroopRecruitment =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.FreeTroopRecruitment != Default.FreeTroopRecruitment
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.FreeTroopRecruitment)
                : SettingsManager.GlobalInstance.FreeTroopRecruitment != Default.FreeTroopRecruitment
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.FreeTroopRecruitment)
                    : new CheatValue<bool>(false, Default.FreeTroopRecruitment);

        public static CheatValue<float> ItemTradingCostPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.ItemTradingCostPercentage != Default.ItemTradingCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.ItemTradingCostPercentage)
                : SettingsManager.GlobalInstance.ItemTradingCostPercentage != Default.ItemTradingCostPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ItemTradingCostPercentage)
                    : new CheatValue<float>(false, Default.ItemTradingCostPercentage);

        public static CheatValue<float> SellingPriceMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.SellingPriceMultiplier != Default.SellingPriceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.SellingPriceMultiplier)
                : SettingsManager.GlobalInstance.SellingPriceMultiplier != Default.SellingPriceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.SellingPriceMultiplier)
                    : new CheatValue<float>(false, Default.SellingPriceMultiplier);

        public static CheatValue<float> TournamentMaximumBetMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.TournamentMaximumBetMultiplier != Default.TournamentMaximumBetMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.TournamentMaximumBetMultiplier)
                : SettingsManager.GlobalInstance.TournamentMaximumBetMultiplier != Default.TournamentMaximumBetMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.TournamentMaximumBetMultiplier)
                    : new CheatValue<float>(false, Default.TournamentMaximumBetMultiplier);

        public static CheatValue<int> DailyFoodBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.DailyFoodBonus != Default.DailyFoodBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.DailyFoodBonus)
                : SettingsManager.GlobalInstance.DailyFoodBonus != Default.DailyFoodBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyFoodBonus)
                    : new CheatValue<int>(false, Default.DailyFoodBonus);

        public static CheatValue<int> DailyGarrisonBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.DailyGarrisonBonus != Default.DailyGarrisonBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.DailyGarrisonBonus)
                : SettingsManager.GlobalInstance.DailyGarrisonBonus != Default.DailyGarrisonBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyGarrisonBonus)
                    : new CheatValue<int>(false, Default.DailyGarrisonBonus);

        public static CheatValue<int> DailyMilitiaBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.DailyMilitiaBonus != Default.DailyMilitiaBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.DailyMilitiaBonus)
                : SettingsManager.GlobalInstance.DailyMilitiaBonus != Default.DailyMilitiaBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyMilitiaBonus)
                    : new CheatValue<int>(false, Default.DailyMilitiaBonus);

        public static CheatValue<int> DailyProsperityBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.DailyProsperityBonus != Default.DailyProsperityBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.DailyProsperityBonus)
                : SettingsManager.GlobalInstance.DailyProsperityBonus != Default.DailyProsperityBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyProsperityBonus)
                    : new CheatValue<int>(false, Default.DailyProsperityBonus);

        public static CheatValue<int> DailyLoyaltyBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.DailyLoyaltyBonus != Default.DailyLoyaltyBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.DailyLoyaltyBonus)
                : SettingsManager.GlobalInstance.DailyLoyaltyBonus != Default.DailyLoyaltyBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyLoyaltyBonus)
                    : new CheatValue<int>(false, Default.DailyLoyaltyBonus);

        public static CheatValue<int> DailySecurityBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.DailySecurityBonus != Default.DailySecurityBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.DailySecurityBonus)
                : SettingsManager.GlobalInstance.DailySecurityBonus != Default.DailySecurityBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailySecurityBonus)
                    : new CheatValue<int>(false, Default.DailySecurityBonus);

        public static CheatValue<int> DailyHearthsBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.DailyHearthsBonus != Default.DailyHearthsBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.DailyHearthsBonus)
                : SettingsManager.GlobalInstance.DailyHearthsBonus != Default.DailyHearthsBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyHearthsBonus)
                    : new CheatValue<int>(false, Default.DailyHearthsBonus);

        public static CheatValue<float> GarrisonWagesPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.GarrisonWagesPercentage != Default.GarrisonWagesPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.GarrisonWagesPercentage)
                : SettingsManager.GlobalInstance.GarrisonWagesPercentage != Default.GarrisonWagesPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.GarrisonWagesPercentage)
                    : new CheatValue<float>(false, Default.GarrisonWagesPercentage);

        public static CheatValue<bool> NeverRequireCivilianEquipment =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.NeverRequireCivilianEquipment != Default.NeverRequireCivilianEquipment
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NeverRequireCivilianEquipment)
                : SettingsManager.GlobalInstance.NeverRequireCivilianEquipment != Default.NeverRequireCivilianEquipment
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NeverRequireCivilianEquipment)
                    : new CheatValue<bool>(false, Default.NeverRequireCivilianEquipment);

        public static CheatValue<float> ConstructionPowerMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.ConstructionPowerMultiplier != Default.ConstructionPowerMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.ConstructionPowerMultiplier)
                : SettingsManager.GlobalInstance.ConstructionPowerMultiplier != Default.ConstructionPowerMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ConstructionPowerMultiplier)
                    : new CheatValue<float>(false, Default.ConstructionPowerMultiplier);

        public static CheatValue<bool> NoBribeToEnterKeep =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.NoBribeToEnterKeep != Default.NoBribeToEnterKeep
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.NoBribeToEnterKeep)
                : SettingsManager.GlobalInstance.NoBribeToEnterKeep != Default.NoBribeToEnterKeep
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoBribeToEnterKeep)
                    : new CheatValue<bool>(false, Default.NoBribeToEnterKeep);

        public static CheatValue<bool> SettlementsNeverRebel =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.SettlementsNeverRebel != Default.SettlementsNeverRebel
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.SettlementsNeverRebel)
                : SettingsManager.GlobalInstance.SettlementsNeverRebel != Default.SettlementsNeverRebel
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.SettlementsNeverRebel)
                    : new CheatValue<bool>(false, Default.SettlementsNeverRebel);

        #endregion Settlements

        #region Smithing

        public static CheatValue<float> SmithingEnergyCostPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.SmithingEnergyCostPercentage != Default.SmithingEnergyCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.SmithingEnergyCostPercentage)
                : SettingsManager.GlobalInstance.SmithingEnergyCostPercentage != Default.SmithingEnergyCostPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.SmithingEnergyCostPercentage)
                    : new CheatValue<float>(false, Default.SmithingEnergyCostPercentage);

        public static CheatValue<bool> UnlockAllParts =>
            SettingsManager.IsPerCampaignInstanceLoaded &&
            SettingsManager.PerCampaignInstance.UnlockAllParts != Default.UnlockAllParts
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.UnlockAllParts)
                : SettingsManager.GlobalInstance.UnlockAllParts != Default.UnlockAllParts
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.UnlockAllParts)
                    : new CheatValue<bool>(false, Default.UnlockAllParts);

        public static CheatValue<float> SmithingDifficultyPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.SmithingDifficultyPercentage != Default.SmithingDifficultyPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.SmithingDifficultyPercentage)
                : SettingsManager.GlobalInstance.SmithingDifficultyPercentage != Default.SmithingDifficultyPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.SmithingDifficultyPercentage)
                    : new CheatValue<float>(false, Default.SmithingDifficultyPercentage);

        public static CheatValue<float> SmithingCostPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.SmithingCostPercentage != Default.SmithingCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.SmithingCostPercentage)
                : SettingsManager.GlobalInstance.SmithingCostPercentage != Default.SmithingCostPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.SmithingCostPercentage)
                    : new CheatValue<float>(false, Default.SmithingCostPercentage);

        public static CheatValue<int> CraftedWeaponHandlingBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.CraftedWeaponHandlingBonus != Default.CraftedWeaponHandlingBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.CraftedWeaponHandlingBonus)
                : SettingsManager.GlobalInstance.CraftedWeaponHandlingBonus != Default.CraftedWeaponHandlingBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.CraftedWeaponHandlingBonus)
                    : new CheatValue<int>(false, Default.CraftedWeaponHandlingBonus);

        public static CheatValue<int> CraftedWeaponSwingDamageBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.CraftedWeaponSwingDamageBonus != Default.CraftedWeaponSwingDamageBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.CraftedWeaponSwingDamageBonus)
                : SettingsManager.GlobalInstance.CraftedWeaponSwingDamageBonus != Default.CraftedWeaponSwingDamageBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.CraftedWeaponSwingDamageBonus)
                    : new CheatValue<int>(false, Default.CraftedWeaponSwingDamageBonus);

        public static CheatValue<int> CraftedWeaponSwingSpeedBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.CraftedWeaponSwingSpeedBonus != Default.CraftedWeaponSwingSpeedBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.CraftedWeaponSwingSpeedBonus)
                : SettingsManager.GlobalInstance.CraftedWeaponSwingSpeedBonus != Default.CraftedWeaponSwingSpeedBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.CraftedWeaponSwingSpeedBonus)
                    : new CheatValue<int>(false, Default.CraftedWeaponSwingSpeedBonus);

        public static CheatValue<int> CraftedWeaponThrustDamageBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.CraftedWeaponThrustDamageBonus != Default.CraftedWeaponThrustDamageBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.CraftedWeaponThrustDamageBonus)
                : SettingsManager.GlobalInstance.CraftedWeaponThrustDamageBonus != Default.CraftedWeaponThrustDamageBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.CraftedWeaponThrustDamageBonus)
                    : new CheatValue<int>(false, Default.CraftedWeaponThrustDamageBonus);

        public static CheatValue<int> CraftedWeaponThrustSpeedBonus =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.CraftedWeaponThrustSpeedBonus != Default.CraftedWeaponThrustSpeedBonus
                ? new CheatValue<int>(true, SettingsManager.PerCampaignInstance.CraftedWeaponThrustSpeedBonus)
                : SettingsManager.GlobalInstance.CraftedWeaponThrustSpeedBonus != Default.CraftedWeaponThrustSpeedBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.CraftedWeaponThrustSpeedBonus)
                    : new CheatValue<int>(false, Default.CraftedWeaponThrustSpeedBonus);

        #endregion Smithing

        #region Workshops

        public static CheatValue<float> WorkshopBuyingCostPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.WorkshopBuyingCostPercentage != Default.WorkshopBuyingCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.WorkshopBuyingCostPercentage)
                : SettingsManager.GlobalInstance.WorkshopBuyingCostPercentage != Default.WorkshopBuyingCostPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.WorkshopBuyingCostPercentage)
                    : new CheatValue<float>(false, Default.WorkshopBuyingCostPercentage);

        public static CheatValue<float> WorkshopDailyExpensePercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.WorkshopDailyExpensePercentage != Default.WorkshopDailyExpensePercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.WorkshopDailyExpensePercentage)
                : SettingsManager.GlobalInstance.WorkshopDailyExpensePercentage != Default.WorkshopDailyExpensePercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.WorkshopDailyExpensePercentage)
                    : new CheatValue<float>(false, Default.WorkshopDailyExpensePercentage);

        public static CheatValue<float> WorkshopUpgradeCostPercentage =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.WorkshopUpgradeCostPercentage != Default.WorkshopUpgradeCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.WorkshopUpgradeCostPercentage)
                : SettingsManager.GlobalInstance.WorkshopUpgradeCostPercentage != Default.WorkshopUpgradeCostPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.WorkshopUpgradeCostPercentage)
                    : new CheatValue<float>(false, Default.WorkshopUpgradeCostPercentage);

        public static CheatValue<float> WorkshopSellingCostMultiplier =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.WorkshopSellingCostMultiplier != Default.WorkshopSellingCostMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerCampaignInstance.WorkshopSellingCostMultiplier)
                : SettingsManager.GlobalInstance.WorkshopSellingCostMultiplier != Default.WorkshopSellingCostMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.WorkshopSellingCostMultiplier)
                    : new CheatValue<float>(false, Default.WorkshopSellingCostMultiplier);

        public static CheatValue<bool> EveryoneBuysWorkshops =>
            SettingsManager.IsPerCampaignInstanceLoaded && SettingsManager.PerCampaignInstance.EveryoneBuysWorkshops != Default.EveryoneBuysWorkshops
                ? new CheatValue<bool>(true, SettingsManager.PerCampaignInstance.EveryoneBuysWorkshops)
                : SettingsManager.GlobalInstance.EveryoneBuysWorkshops != Default.EveryoneBuysWorkshops
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.EveryoneBuysWorkshops)
                    : new CheatValue<bool>(false, Default.EveryoneBuysWorkshops);

        #endregion Workshops
    }
}
