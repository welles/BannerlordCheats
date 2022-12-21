using System;
using BannerlordCheats.Extensions;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace BannerlordCheats.Settings
{
    public static partial class SettingsManager
    {
        private static bool IsPerSaveInstanceLoaded => BannerlordCheatsPerSaveSettings.Instance != null;

        private static BannerlordCheatsGlobalSettings GlobalInstance =>
            BannerlordCheatsGlobalSettings.Instance ?? throw new InvalidOperationException("Should have checked if global instance is loaded!");

        private static BannerlordCheatsPerSaveSettings PerSaveInstance =>
            BannerlordCheatsPerSaveSettings.Instance ?? throw new InvalidOperationException("Should have checked if per-save instance is loaded!");

        #region Global

        public static CheatValue<bool> EnableHotkeys =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.EnableHotkeys != Default.EnableHotkeys
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.EnableHotkeys)
                : SettingsManager.GlobalInstance.EnableHotkeys != Default.EnableHotkeys
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.EnableHotkeys)
                    : new CheatValue<bool>(false, Default.EnableHotkeys);

        public static CheatValue<bool> EnableHotkeyTips =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.EnableHotkeyTips != Default.EnableHotkeyTips
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.EnableHotkeyTips)
                : SettingsManager.GlobalInstance.EnableHotkeyTips != Default.EnableHotkeyTips
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.EnableHotkeyTips)
                    : new CheatValue<bool>(false, Default.EnableHotkeyTips);

        #endregion Global

        #region Map

        public static CheatValue<float> MapSpeedMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.MapSpeedMultiplier != Default.MapSpeedMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.MapSpeedMultiplier)
                : SettingsManager.GlobalInstance.MapSpeedMultiplier != Default.MapSpeedMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.MapSpeedMultiplier)
                    : new CheatValue<float>(false, Default.MapSpeedMultiplier);

        public static CheatValue<float> MapVisibilityMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.MapVisibilityMultiplier != Default.MapVisibilityMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.MapVisibilityMultiplier)
                : SettingsManager.GlobalInstance.MapVisibilityMultiplier != Default.MapVisibilityMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.MapVisibilityMultiplier)
                    : new CheatValue<float>(false, Default.MapVisibilityMultiplier);

        public static CheatValue<float> NpcMapSpeedPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.NpcMapSpeedPercentage != Default.NpcMapSpeedPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.NpcMapSpeedPercentage)
                : SettingsManager.GlobalInstance.NpcMapSpeedPercentage != Default.NpcMapSpeedPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.NpcMapSpeedPercentage)
                    : new CheatValue<float>(false, Default.NpcMapSpeedPercentage);

        public static CheatValue<bool> PartyInvisibleOnMap =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.PartyInvisibleOnMap != Default.PartyInvisibleOnMap
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.PartyInvisibleOnMap)
                : SettingsManager.GlobalInstance.PartyInvisibleOnMap != Default.PartyInvisibleOnMap
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PartyInvisibleOnMap)
                    : new CheatValue<bool>(false, Default.PartyInvisibleOnMap);

        public static CheatValue<bool> CaravansInvisibleOnMap =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.CaravansInvisibleOnMap != Default.CaravansInvisibleOnMap
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.CaravansInvisibleOnMap)
                : SettingsManager.GlobalInstance.CaravansInvisibleOnMap != Default.CaravansInvisibleOnMap
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.CaravansInvisibleOnMap)
                    : new CheatValue<bool>(false, Default.CaravansInvisibleOnMap);

        #endregion Map

        #region Combat - Player

        public static CheatValue<float> DamageTakenPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.DamageTakenPercentage != Default.DamageTakenPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.DamageTakenPercentage)
                : SettingsManager.GlobalInstance.DamageTakenPercentage != Default.DamageTakenPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.DamageTakenPercentage)
                    : new CheatValue<float>(false, Default.DamageTakenPercentage);

        public static CheatValue<bool> Invincible =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.Invincible != Default.Invincible
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.Invincible)
                : SettingsManager.GlobalInstance.Invincible != Default.Invincible
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.Invincible)
                    : new CheatValue<bool>(false, Default.Invincible);

        public static CheatValue<bool> PlayerHorseInvincible =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.PlayerHorseInvincible != Default.PlayerHorseInvincible
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.PlayerHorseInvincible)
                : SettingsManager.GlobalInstance.PlayerHorseInvincible != Default.PlayerHorseInvincible
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PlayerHorseInvincible)
                    : new CheatValue<bool>(false, Default.PlayerHorseInvincible);

        public static CheatValue<bool> OneHitKill =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.OneHitKill != Default.OneHitKill
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.OneHitKill)
                : SettingsManager.GlobalInstance.OneHitKill != Default.OneHitKill
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.OneHitKill)
                    : new CheatValue<bool>(false, Default.OneHitKill);

        public static CheatValue<bool> AlwaysCrushThroughShields =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.AlwaysCrushThroughShields != Default.AlwaysCrushThroughShields
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.AlwaysCrushThroughShields)
                : SettingsManager.GlobalInstance.AlwaysCrushThroughShields != Default.AlwaysCrushThroughShields
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.AlwaysCrushThroughShields)
                    : new CheatValue<bool>(false, Default.AlwaysCrushThroughShields);

        public static CheatValue<bool> SliceThroughEveryone =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.SliceThroughEveryone != Default.SliceThroughEveryone
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.SliceThroughEveryone)
                : SettingsManager.GlobalInstance.SliceThroughEveryone != Default.SliceThroughEveryone
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.SliceThroughEveryone)
                    : new CheatValue<bool>(false, Default.SliceThroughEveryone);

        public static CheatValue<float> HealthRegeneration =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.HealthRegeneration != Default.HealthRegeneration
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.HealthRegeneration)
                : SettingsManager.GlobalInstance.HealthRegeneration != Default.HealthRegeneration
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.HealthRegeneration)
                    : new CheatValue<float>(false, Default.HealthRegeneration);

        public static CheatValue<bool> InfiniteAmmo =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.InfiniteAmmo != Default.InfiniteAmmo
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.InfiniteAmmo)
                : SettingsManager.GlobalInstance.InfiniteAmmo != Default.InfiniteAmmo
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.InfiniteAmmo)
                    : new CheatValue<bool>(false, Default.InfiniteAmmo);

        public static CheatValue<float> DamageMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.DamageMultiplier != Default.DamageMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.DamageMultiplier)
                : SettingsManager.GlobalInstance.DamageMultiplier != Default.DamageMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.DamageMultiplier)
                    : new CheatValue<float>(false, Default.DamageMultiplier);

        public static CheatValue<bool> AlwaysKnockDown =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.AlwaysKnockDown != Default.AlwaysKnockDown
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.AlwaysKnockDown)
                : SettingsManager.GlobalInstance.AlwaysKnockDown != Default.AlwaysKnockDown
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.AlwaysKnockDown)
                    : new CheatValue<bool>(false, Default.AlwaysKnockDown);

        public static CheatValue<bool> NeverKnockedBackByAttacks =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.NeverKnockedBackByAttacks != Default.NeverKnockedBackByAttacks
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NeverKnockedBackByAttacks)
                : SettingsManager.GlobalInstance.NeverKnockedBackByAttacks != Default.NeverKnockedBackByAttacks
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NeverKnockedBackByAttacks)
                    : new CheatValue<bool>(false, Default.NeverKnockedBackByAttacks);

        public static CheatValue<bool> NoStuckArrows =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.NoStuckArrows != Default.NoStuckArrows
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NoStuckArrows)
                : SettingsManager.GlobalInstance.NoStuckArrows != Default.NoStuckArrows
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoStuckArrows)
                    : new CheatValue<bool>(false, Default.NoStuckArrows);

        public static CheatValue<bool> InstantCrossbowReload =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.InstantCrossbowReload != Default.InstantCrossbowReload
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.InstantCrossbowReload)
                : SettingsManager.GlobalInstance.InstantCrossbowReload != Default.InstantCrossbowReload
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.InstantCrossbowReload)
                    : new CheatValue<bool>(false, Default.InstantCrossbowReload);

        #endregion Combat - Player

        #region Combat - Party

        public static CheatValue<KnockoutOrKilled> PartyKnockoutOrKilled =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.PartyKnockoutOrKilled.GetValue() != Default.PartyKnockoutOrKilled
                ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.PerSaveInstance.PartyKnockoutOrKilled.GetValue())
                : SettingsManager.GlobalInstance.PartyKnockoutOrKilled.GetValue() != Default.PartyKnockoutOrKilled
                    ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.GlobalInstance.PartyKnockoutOrKilled.GetValue())
                    : new CheatValue<KnockoutOrKilled>(false, Default.PartyKnockoutOrKilled);

        public static CheatValue<KnockoutOrKilled> CompanionsKnockoutOrKilled =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.CompanionsKnockoutOrKilled.GetValue() != Default.CompanionsKnockoutOrKilled
                ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.PerSaveInstance.CompanionsKnockoutOrKilled.GetValue())
                : SettingsManager.GlobalInstance.CompanionsKnockoutOrKilled.GetValue() != Default.CompanionsKnockoutOrKilled
                    ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.GlobalInstance.CompanionsKnockoutOrKilled.GetValue())
                    : new CheatValue<KnockoutOrKilled>(false, Default.CompanionsKnockoutOrKilled);

        public static CheatValue<bool> PartyInvincible =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.PartyInvincible != Default.PartyInvincible
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.PartyInvincible)
                : SettingsManager.GlobalInstance.PartyInvincible != Default.PartyInvincible
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PartyInvincible)
                    : new CheatValue<bool>(false, Default.PartyInvincible);

        public static CheatValue<bool> PartyHeroesInvincible =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.PartyHeroesInvincible != Default.PartyHeroesInvincible
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.PartyHeroesInvincible)
                : SettingsManager.GlobalInstance.PartyHeroesInvincible != Default.PartyHeroesInvincible
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PartyHeroesInvincible)
                    : new CheatValue<bool>(false, Default.PartyHeroesInvincible);

        public static CheatValue<float> PartyDamageTakenPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.PartyDamageTakenPercentage != Default.PartyDamageTakenPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.PartyDamageTakenPercentage)
                : SettingsManager.GlobalInstance.PartyDamageTakenPercentage != Default.PartyDamageTakenPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.PartyDamageTakenPercentage)
                    : new CheatValue<float>(false, Default.PartyDamageTakenPercentage);

        public static CheatValue<bool> PartyOneHitKill =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.PartyOneHitKill != Default.PartyOneHitKill
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.PartyOneHitKill)
                : SettingsManager.GlobalInstance.PartyOneHitKill != Default.PartyOneHitKill
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PartyOneHitKill)
                    : new CheatValue<bool>(false, Default.PartyOneHitKill);

        public static CheatValue<bool> NoRunningAway =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.NoRunningAway != Default.NoRunningAway
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NoRunningAway)
                : SettingsManager.GlobalInstance.NoRunningAway != Default.NoRunningAway
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoRunningAway)
                    : new CheatValue<bool>(false, Default.NoRunningAway);

        public static CheatValue<float> PartyHealthRegeneration =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.PartyHealthRegeneration != Default.PartyHealthRegeneration
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.PartyHealthRegeneration)
                : SettingsManager.GlobalInstance.PartyHealthRegeneration != Default.PartyHealthRegeneration
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.PartyHealthRegeneration)
                    : new CheatValue<float>(false, Default.PartyHealthRegeneration);

        public static CheatValue<bool> PartyInfiniteAmmo =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.PartyInfiniteAmmo != Default.PartyInfiniteAmmo
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.PartyInfiniteAmmo)
                : SettingsManager.GlobalInstance.PartyInfiniteAmmo != Default.PartyInfiniteAmmo
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PartyInfiniteAmmo)
                    : new CheatValue<bool>(false, Default.PartyInfiniteAmmo);

        public static CheatValue<float> PartyDamageMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.PartyDamageMultiplier != Default.PartyDamageMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.PartyDamageMultiplier)
                : SettingsManager.GlobalInstance.PartyDamageMultiplier != Default.PartyDamageMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.PartyDamageMultiplier)
                    : new CheatValue<float>(false, Default.PartyDamageMultiplier);

        public static CheatValue<bool> NoFriendlyFire =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.NoFriendlyFire != Default.NoFriendlyFire
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NoFriendlyFire)
                : SettingsManager.GlobalInstance.NoFriendlyFire != Default.NoFriendlyFire
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoFriendlyFire)
                    : new CheatValue<bool>(false, Default.NoFriendlyFire);

        #endregion Combat - Party

        #region Combat - Allies

        public static CheatValue<KnockoutOrKilled> FriendlyLordsKnockoutOrKilled =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.FriendlyLordsKnockoutOrKilled.GetValue() != Default.FriendlyLordsKnockoutOrKilled
                ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.PerSaveInstance.FriendlyLordsKnockoutOrKilled.GetValue())
                : SettingsManager.GlobalInstance.FriendlyLordsKnockoutOrKilled.GetValue() != Default.FriendlyLordsKnockoutOrKilled
                    ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.GlobalInstance.FriendlyLordsKnockoutOrKilled.GetValue())
                    : new CheatValue<KnockoutOrKilled>(false, Default.FriendlyLordsKnockoutOrKilled);

        #endregion Combat - Allies

        #region Combat - Enemies

        public static CheatValue<KnockoutOrKilled> EnemyLordsKnockoutOrKilled =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.EnemyLordsKnockoutOrKilled.GetValue() != Default.EnemyLordsKnockoutOrKilled
                ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.PerSaveInstance.EnemyLordsKnockoutOrKilled.GetValue())
                : SettingsManager.GlobalInstance.EnemyLordsKnockoutOrKilled.GetValue() != Default.EnemyLordsKnockoutOrKilled
                    ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.GlobalInstance.EnemyLordsKnockoutOrKilled.GetValue())
                    : new CheatValue<KnockoutOrKilled>(false, Default.EnemyLordsKnockoutOrKilled);

        public static CheatValue<KnockoutOrKilled> EnemyTroopsKnockoutOrKilled =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.EnemyTroopsKnockoutOrKilled.GetValue() != Default.EnemyTroopsKnockoutOrKilled
                ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.PerSaveInstance.EnemyTroopsKnockoutOrKilled.GetValue())
                : SettingsManager.GlobalInstance.EnemyTroopsKnockoutOrKilled.GetValue() != Default.EnemyTroopsKnockoutOrKilled
                    ? new CheatValue<KnockoutOrKilled>(true, SettingsManager.GlobalInstance.EnemyTroopsKnockoutOrKilled.GetValue())
                    : new CheatValue<KnockoutOrKilled>(false, Default.EnemyTroopsKnockoutOrKilled);

        public static CheatValue<bool> EnemiesNoRunningAway =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.EnemiesNoRunningAway != Default.EnemiesNoRunningAway
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.EnemiesNoRunningAway)
                : SettingsManager.GlobalInstance.EnemiesNoRunningAway != Default.EnemiesNoRunningAway
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.EnemiesNoRunningAway)
                    : new CheatValue<bool>(false, Default.EnemiesNoRunningAway);

        public static CheatValue<float> EnemyDamagePercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.EnemyDamagePercentage != Default.EnemyDamagePercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.EnemyDamagePercentage)
                : SettingsManager.GlobalInstance.EnemyDamagePercentage != Default.EnemyDamagePercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.EnemyDamagePercentage)
                    : new CheatValue<float>(false, Default.EnemyDamagePercentage);

        #endregion Combat - Enemies

        #region Combat - Misc

        public static CheatValue<float> RenownRewardMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.RenownRewardMultiplier != Default.RenownRewardMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.RenownRewardMultiplier)
                : SettingsManager.GlobalInstance.RenownRewardMultiplier != Default.RenownRewardMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.RenownRewardMultiplier)
                    : new CheatValue<float>(false, Default.RenownRewardMultiplier);

        public static CheatValue<float> InfluenceRewardMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.InfluenceRewardMultiplier != Default.InfluenceRewardMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.InfluenceRewardMultiplier)
                : SettingsManager.GlobalInstance.InfluenceRewardMultiplier != Default.InfluenceRewardMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.InfluenceRewardMultiplier)
                    : new CheatValue<float>(false, Default.InfluenceRewardMultiplier);

        public static CheatValue<bool> AlwaysWinBattleSimulation =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.AlwaysWinBattleSimulation != Default.AlwaysWinBattleSimulation
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.AlwaysWinBattleSimulation)
                : SettingsManager.GlobalInstance.AlwaysWinBattleSimulation != Default.AlwaysWinBattleSimulation
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.AlwaysWinBattleSimulation)
                    : new CheatValue<bool>(false, Default.AlwaysWinBattleSimulation);

        public static CheatValue<bool> NoTroopSacrifice =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.NoTroopSacrifice != Default.NoTroopSacrifice
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NoTroopSacrifice)
                : SettingsManager.GlobalInstance.NoTroopSacrifice != Default.NoTroopSacrifice
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoTroopSacrifice)
                    : new CheatValue<bool>(false, Default.NoTroopSacrifice);

        public static CheatValue<int> BanditHideoutTroopLimit =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.BanditHideoutTroopLimit != Default.BanditHideoutTroopLimit
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.BanditHideoutTroopLimit)
                : SettingsManager.GlobalInstance.BanditHideoutTroopLimit != Default.BanditHideoutTroopLimit
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.BanditHideoutTroopLimit)
                    : new CheatValue<int>(false, Default.BanditHideoutTroopLimit);

        public static CheatValue<float> CombatZoomMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.CombatZoomMultiplier != Default.CombatZoomMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.CombatZoomMultiplier)
                : SettingsManager.GlobalInstance.CombatZoomMultiplier != Default.CombatZoomMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.CombatZoomMultiplier)
                    : new CheatValue<float>(false, Default.CombatZoomMultiplier);

        #endregion Combat - Misc

        #region Inventory

        public static CheatValue<int> ExtraInventoryCapacity =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.ExtraInventoryCapacity != Default.ExtraInventoryCapacity
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.ExtraInventoryCapacity)
                : SettingsManager.GlobalInstance.ExtraInventoryCapacity != Default.ExtraInventoryCapacity
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraInventoryCapacity)
                    : new CheatValue<int>(false, Default.ExtraInventoryCapacity);

        public static CheatValue<bool> NativeItemSpawning =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.NativeItemSpawning != Default.NativeItemSpawning
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NativeItemSpawning)
                : SettingsManager.GlobalInstance.NativeItemSpawning != Default.NativeItemSpawning
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NativeItemSpawning)
                    : new CheatValue<bool>(false, Default.NativeItemSpawning);

        #endregion Inventory

        #region Party

        public static CheatValue<int> ExtraPartyMemberSize =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.ExtraPartyMemberSize != Default.ExtraPartyMemberSize
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.ExtraPartyMemberSize)
                : SettingsManager.GlobalInstance.ExtraPartyMemberSize != Default.ExtraPartyMemberSize
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraPartyMemberSize)
                    : new CheatValue<int>(false, Default.ExtraPartyMemberSize);

        public static CheatValue<int> ExtraPartyPrisonerSize =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.ExtraPartyPrisonerSize != Default.ExtraPartyPrisonerSize
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.ExtraPartyPrisonerSize)
                : SettingsManager.GlobalInstance.ExtraPartyPrisonerSize != Default.ExtraPartyPrisonerSize
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraPartyPrisonerSize)
                    : new CheatValue<int>(false, Default.ExtraPartyPrisonerSize);

        public static CheatValue<int> ExtraPartyMorale =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.ExtraPartyMorale != Default.ExtraPartyMorale
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.ExtraPartyMorale)
                : SettingsManager.GlobalInstance.ExtraPartyMorale != Default.ExtraPartyMorale
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraPartyMorale)
                    : new CheatValue<int>(false, Default.ExtraPartyMorale);

        public static CheatValue<bool> InstantEscape =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.InstantEscape != Default.InstantEscape
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.InstantEscape)
                : SettingsManager.GlobalInstance.InstantEscape != Default.InstantEscape
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.InstantEscape)
                    : new CheatValue<bool>(false, Default.InstantEscape);

        public static CheatValue<float> FoodConsumptionPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.FoodConsumptionPercentage != Default.FoodConsumptionPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.FoodConsumptionPercentage)
                : SettingsManager.GlobalInstance.FoodConsumptionPercentage != Default.FoodConsumptionPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.FoodConsumptionPercentage)
                    : new CheatValue<float>(false, Default.FoodConsumptionPercentage);

        public static CheatValue<float> TroopWagesPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.TroopWagesPercentage != Default.TroopWagesPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.TroopWagesPercentage)
                : SettingsManager.GlobalInstance.TroopWagesPercentage != Default.TroopWagesPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.TroopWagesPercentage)
                    : new CheatValue<float>(false, Default.TroopWagesPercentage);

        public static CheatValue<bool> FreeTroopUpgrades =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.FreeTroopUpgrades != Default.FreeTroopUpgrades
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.FreeTroopUpgrades)
                : SettingsManager.GlobalInstance.FreeTroopUpgrades != Default.FreeTroopUpgrades
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.FreeTroopUpgrades)
                    : new CheatValue<bool>(false, Default.FreeTroopUpgrades);

        public static CheatValue<bool> FreeCompanionHiring =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.FreeCompanionHiring != Default.FreeCompanionHiring
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.FreeCompanionHiring)
                : SettingsManager.GlobalInstance.FreeCompanionHiring != Default.FreeCompanionHiring
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.FreeCompanionHiring)
                    : new CheatValue<bool>(false, Default.FreeCompanionHiring);

        public static CheatValue<bool> InstantPrisonerRecruitment =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.InstantPrisonerRecruitment != Default.InstantPrisonerRecruitment
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.InstantPrisonerRecruitment)
                : SettingsManager.GlobalInstance.InstantPrisonerRecruitment != Default.InstantPrisonerRecruitment
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.InstantPrisonerRecruitment)
                    : new CheatValue<bool>(false, Default.InstantPrisonerRecruitment);

        public static CheatValue<bool> NoPrisonerEscape =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.NoPrisonerEscape != Default.NoPrisonerEscape
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NoPrisonerEscape)
                : SettingsManager.GlobalInstance.NoPrisonerEscape != Default.NoPrisonerEscape
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoPrisonerEscape)
                    : new CheatValue<bool>(false, Default.NoPrisonerEscape);

        public static CheatValue<float> PartyHealingMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.PartyHealingMultiplier != Default.PartyHealingMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.PartyHealingMultiplier)
                : SettingsManager.GlobalInstance.PartyHealingMultiplier != Default.PartyHealingMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.PartyHealingMultiplier)
                    : new CheatValue<float>(false, Default.PartyHealingMultiplier);

        #endregion

        #region Clan

        public static CheatValue<int> ExtraCompanionLimit =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.ExtraCompanionLimit != Default.ExtraCompanionLimit
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.ExtraCompanionLimit)
                : SettingsManager.GlobalInstance.ExtraCompanionLimit != Default.ExtraCompanionLimit
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraCompanionLimit)
                    : new CheatValue<int>(false, Default.ExtraCompanionLimit);

        public static CheatValue<int> ExtraClanPartyLimit =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.ExtraClanPartyLimit != Default.ExtraClanPartyLimit
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.ExtraClanPartyLimit)
                : SettingsManager.GlobalInstance.ExtraClanPartyLimit != Default.ExtraClanPartyLimit
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraClanPartyLimit)
                    : new CheatValue<int>(false, Default.ExtraClanPartyLimit);

        public static CheatValue<int> ExtraClanPartySize =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.ExtraClanPartySize != Default.ExtraClanPartySize
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.ExtraClanPartySize)
                : SettingsManager.GlobalInstance.ExtraClanPartySize != Default.ExtraClanPartySize
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.ExtraClanPartySize)
                    : new CheatValue<int>(false, Default.ExtraClanPartySize);

        #endregion Clan

        #region Characters

        public static CheatValue<bool> PerfectRelationships =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.PerfectRelationships != Default.PerfectRelationships
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.PerfectRelationships)
                : SettingsManager.GlobalInstance.PerfectRelationships != Default.PerfectRelationships
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PerfectRelationships)
                    : new CheatValue<bool>(false, Default.PerfectRelationships);

        public static CheatValue<bool> NeverDieOfOldAge =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.NeverDieOfOldAge != Default.NeverDieOfOldAge
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NeverDieOfOldAge)
                : SettingsManager.GlobalInstance.NeverDieOfOldAge != Default.NeverDieOfOldAge
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NeverDieOfOldAge)
                    : new CheatValue<bool>(false, Default.NeverDieOfOldAge);

        public static CheatValue<bool> BarterOfferAlwaysAccepted =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.BarterOfferAlwaysAccepted != Default.BarterOfferAlwaysAccepted
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.BarterOfferAlwaysAccepted)
                : SettingsManager.GlobalInstance.BarterOfferAlwaysAccepted != Default.BarterOfferAlwaysAccepted
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.BarterOfferAlwaysAccepted)
                    : new CheatValue<bool>(false, Default.BarterOfferAlwaysAccepted);

        public static CheatValue<bool> NoBarterCooldown =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.NoBarterCooldown != Default.NoBarterCooldown
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NoBarterCooldown)
                : SettingsManager.GlobalInstance.NoBarterCooldown != Default.NoBarterCooldown
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoBarterCooldown)
                    : new CheatValue<bool>(false, Default.NoBarterCooldown);

        public static CheatValue<bool> ConversationAlwaysSuccessful =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.ConversationAlwaysSuccessful != Default.ConversationAlwaysSuccessful
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.ConversationAlwaysSuccessful)
                : SettingsManager.GlobalInstance.ConversationAlwaysSuccessful != Default.ConversationAlwaysSuccessful
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.ConversationAlwaysSuccessful)
                    : new CheatValue<bool>(false, Default.ConversationAlwaysSuccessful);

        public static CheatValue<bool> PerfectAttraction =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.PerfectAttraction != Default.PerfectAttraction
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.PerfectAttraction)
                : SettingsManager.GlobalInstance.PerfectAttraction != Default.PerfectAttraction
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.PerfectAttraction)
                    : new CheatValue<bool>(false, Default.PerfectAttraction);

        public static CheatValue<bool> AllowSameSexMarriage =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.AllowSameSexMarriage != Default.AllowSameSexMarriage
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.AllowSameSexMarriage)
                : SettingsManager.GlobalInstance.AllowSameSexMarriage != Default.AllowSameSexMarriage
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.AllowSameSexMarriage)
                    : new CheatValue<bool>(false, Default.AllowSameSexMarriage);

        public static CheatValue<float> PregnancyChanceMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.PregnancyChanceMultiplier != Default.PregnancyChanceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.PregnancyChanceMultiplier)
                : SettingsManager.GlobalInstance.PregnancyChanceMultiplier != Default.PregnancyChanceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.PregnancyChanceMultiplier)
                    : new CheatValue<float>(false, Default.PregnancyChanceMultiplier);

        public static CheatValue<int> AdjustPregnancyDuration =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.AdjustPregnancyDuration != Default.AdjustPregnancyDuration
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.AdjustPregnancyDuration)
                : SettingsManager.GlobalInstance.AdjustPregnancyDuration != Default.AdjustPregnancyDuration
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.AdjustPregnancyDuration)
                    : new CheatValue<int>(false, Default.AdjustPregnancyDuration);

        #endregion Characters

        #region Kingdom

        public static CheatValue<float> KingdomDecisionWeightMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.KingdomDecisionWeightMultiplier != Default.KingdomDecisionWeightMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.KingdomDecisionWeightMultiplier)
                : SettingsManager.GlobalInstance.KingdomDecisionWeightMultiplier != Default.KingdomDecisionWeightMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.KingdomDecisionWeightMultiplier)
                    : new CheatValue<float>(false, Default.KingdomDecisionWeightMultiplier);

        public static CheatValue<bool> NoRelationshipLossOnDecision =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.NoRelationshipLossOnDecision != Default.NoRelationshipLossOnDecision
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NoRelationshipLossOnDecision)
                : SettingsManager.GlobalInstance.NoRelationshipLossOnDecision != Default.NoRelationshipLossOnDecision
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoRelationshipLossOnDecision)
                    : new CheatValue<bool>(false, Default.NoRelationshipLossOnDecision);

        public static CheatValue<bool> NoCrimeRatingForCrimes =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.NoCrimeRatingForCrimes != Default.NoCrimeRatingForCrimes
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NoCrimeRatingForCrimes)
                : SettingsManager.GlobalInstance.NoCrimeRatingForCrimes != Default.NoCrimeRatingForCrimes
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoCrimeRatingForCrimes)
                    : new CheatValue<bool>(false, Default.NoCrimeRatingForCrimes);

        public static CheatValue<float> DecisionOverrideInfluenceCostPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.DecisionOverrideInfluenceCostPercentage != Default.DecisionOverrideInfluenceCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.DecisionOverrideInfluenceCostPercentage)
                : SettingsManager.GlobalInstance.DecisionOverrideInfluenceCostPercentage != Default.DecisionOverrideInfluenceCostPercentage
                    ? new CheatValue<float>(true,
                        SettingsManager.GlobalInstance.DecisionOverrideInfluenceCostPercentage)
                    : new CheatValue<float>(false, Default.DecisionOverrideInfluenceCostPercentage);

        #endregion Kingdom

        #region Experience

        public static CheatValue<float> ExperienceMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.ExperienceMultiplier != Default.ExperienceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.ExperienceMultiplier)
                : SettingsManager.GlobalInstance.ExperienceMultiplier != Default.ExperienceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ExperienceMultiplier)
                    : new CheatValue<float>(false, Default.ExperienceMultiplier);

        public static CheatValue<float> CompanionExperienceMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.CompanionExperienceMultiplier != Default.CompanionExperienceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.CompanionExperienceMultiplier)
                : SettingsManager.GlobalInstance.CompanionExperienceMultiplier != Default.CompanionExperienceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.CompanionExperienceMultiplier)
                    : new CheatValue<float>(false, Default.CompanionExperienceMultiplier);

        public static CheatValue<float> LearningRateMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.LearningRateMultiplier != Default.LearningRateMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.LearningRateMultiplier)
                : SettingsManager.GlobalInstance.LearningRateMultiplier != Default.LearningRateMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.LearningRateMultiplier)
                    : new CheatValue<float>(false, Default.LearningRateMultiplier);

        public static CheatValue<float> CompanionLearningRateMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.CompanionLearningRateMultiplier != Default.CompanionLearningRateMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.CompanionLearningRateMultiplier)
                : SettingsManager.GlobalInstance.CompanionLearningRateMultiplier != Default.CompanionLearningRateMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.CompanionLearningRateMultiplier)
                    : new CheatValue<float>(false, Default.CompanionLearningRateMultiplier);

        public static CheatValue<float> LearningLimitMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.LearningLimitMultiplier != Default.LearningLimitMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.LearningLimitMultiplier)
                : SettingsManager.GlobalInstance.LearningLimitMultiplier != Default.LearningLimitMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.LearningLimitMultiplier)
                    : new CheatValue<float>(false, Default.LearningLimitMultiplier);

        public static CheatValue<float> TroopExperienceMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.TroopExperienceMultiplier != Default.TroopExperienceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.TroopExperienceMultiplier)
                : SettingsManager.GlobalInstance.TroopExperienceMultiplier != Default.TroopExperienceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.TroopExperienceMultiplier)
                    : new CheatValue<float>(false, Default.TroopExperienceMultiplier);

        public static CheatValue<bool> FreeFocusPointAssignment =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.FreeFocusPointAssignment != Default.FreeFocusPointAssignment
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.FreeFocusPointAssignment)
                : SettingsManager.GlobalInstance.FreeFocusPointAssignment != Default.FreeFocusPointAssignment
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.FreeFocusPointAssignment)
                    : new CheatValue<bool>(false, Default.FreeFocusPointAssignment);

        #endregion Experience

        #region Sieges

        public static CheatValue<float> SiegeBuildingSpeedMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.SiegeBuildingSpeedMultiplier != Default.SiegeBuildingSpeedMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.SiegeBuildingSpeedMultiplier)
                : SettingsManager.GlobalInstance.SiegeBuildingSpeedMultiplier != Default.SiegeBuildingSpeedMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.SiegeBuildingSpeedMultiplier)
                    : new CheatValue<float>(false, Default.SiegeBuildingSpeedMultiplier);

        public static CheatValue<float> EnemySiegeBuildingSpeedPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.EnemySiegeBuildingSpeedPercentage != Default.EnemySiegeBuildingSpeedPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.EnemySiegeBuildingSpeedPercentage)
                : SettingsManager.GlobalInstance.EnemySiegeBuildingSpeedPercentage != Default.EnemySiegeBuildingSpeedPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.EnemySiegeBuildingSpeedPercentage)
                    : new CheatValue<float>(false, Default.EnemySiegeBuildingSpeedPercentage);

        #endregion Sieges

        #region Army

        public static CheatValue<float> FactionArmyCohesionLossPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.FactionArmyCohesionLossPercentage != Default.FactionArmyCohesionLossPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.FactionArmyCohesionLossPercentage)
                : SettingsManager.GlobalInstance.FactionArmyCohesionLossPercentage != Default.FactionArmyCohesionLossPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.FactionArmyCohesionLossPercentage)
                    : new CheatValue<float>(false, Default.FactionArmyCohesionLossPercentage);

        public static CheatValue<float> ArmyCohesionLossPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.ArmyCohesionLossPercentage != Default.ArmyCohesionLossPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.ArmyCohesionLossPercentage)
                : SettingsManager.GlobalInstance.ArmyCohesionLossPercentage != Default.ArmyCohesionLossPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ArmyCohesionLossPercentage)
                    : new CheatValue<float>(false, Default.ArmyCohesionLossPercentage);

        public static CheatValue<float> ArmyFoodConsumptionPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.ArmyFoodConsumptionPercentage != Default.ArmyFoodConsumptionPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.ArmyFoodConsumptionPercentage)
                : SettingsManager.GlobalInstance.ArmyFoodConsumptionPercentage != Default.ArmyFoodConsumptionPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ArmyFoodConsumptionPercentage)
                    : new CheatValue<float>(false, Default.ArmyFoodConsumptionPercentage);

        #endregion Army

        #region Settlements

        public static CheatValue<bool> DisguiseAlwaysWorks =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.DisguiseAlwaysWorks != Default.DisguiseAlwaysWorks
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.DisguiseAlwaysWorks)
                : SettingsManager.GlobalInstance.DisguiseAlwaysWorks != Default.DisguiseAlwaysWorks
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.DisguiseAlwaysWorks)
                    : new CheatValue<bool>(false, Default.DisguiseAlwaysWorks);

        public static CheatValue<bool> FreeTroopRecruitment =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.FreeTroopRecruitment != Default.FreeTroopRecruitment
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.FreeTroopRecruitment)
                : SettingsManager.GlobalInstance.FreeTroopRecruitment != Default.FreeTroopRecruitment
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.FreeTroopRecruitment)
                    : new CheatValue<bool>(false, Default.FreeTroopRecruitment);

        public static CheatValue<float> ItemTradingCostPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.ItemTradingCostPercentage != Default.ItemTradingCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.ItemTradingCostPercentage)
                : SettingsManager.GlobalInstance.ItemTradingCostPercentage != Default.ItemTradingCostPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ItemTradingCostPercentage)
                    : new CheatValue<float>(false, Default.ItemTradingCostPercentage);

        public static CheatValue<float> SellingPriceMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.SellingPriceMultiplier != Default.SellingPriceMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.SellingPriceMultiplier)
                : SettingsManager.GlobalInstance.SellingPriceMultiplier != Default.SellingPriceMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.SellingPriceMultiplier)
                    : new CheatValue<float>(false, Default.SellingPriceMultiplier);

        public static CheatValue<float> TournamentMaximumBetMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.TournamentMaximumBetMultiplier != Default.TournamentMaximumBetMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.TournamentMaximumBetMultiplier)
                : SettingsManager.GlobalInstance.TournamentMaximumBetMultiplier != Default.TournamentMaximumBetMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.TournamentMaximumBetMultiplier)
                    : new CheatValue<float>(false, Default.TournamentMaximumBetMultiplier);

        public static CheatValue<int> DailyFoodBonus =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.DailyFoodBonus != Default.DailyFoodBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.DailyFoodBonus)
                : SettingsManager.GlobalInstance.DailyFoodBonus != Default.DailyFoodBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyFoodBonus)
                    : new CheatValue<int>(false, Default.DailyFoodBonus);

        public static CheatValue<int> DailyGarrisonBonus =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.DailyGarrisonBonus != Default.DailyGarrisonBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.DailyGarrisonBonus)
                : SettingsManager.GlobalInstance.DailyGarrisonBonus != Default.DailyGarrisonBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyGarrisonBonus)
                    : new CheatValue<int>(false, Default.DailyGarrisonBonus);

        public static CheatValue<int> DailyMilitiaBonus =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.DailyMilitiaBonus != Default.DailyMilitiaBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.DailyMilitiaBonus)
                : SettingsManager.GlobalInstance.DailyMilitiaBonus != Default.DailyMilitiaBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyMilitiaBonus)
                    : new CheatValue<int>(false, Default.DailyMilitiaBonus);

        public static CheatValue<int> DailyProsperityBonus =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.DailyProsperityBonus != Default.DailyProsperityBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.DailyProsperityBonus)
                : SettingsManager.GlobalInstance.DailyProsperityBonus != Default.DailyProsperityBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyProsperityBonus)
                    : new CheatValue<int>(false, Default.DailyProsperityBonus);

        public static CheatValue<int> DailyLoyaltyBonus =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.DailyLoyaltyBonus != Default.DailyLoyaltyBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.DailyLoyaltyBonus)
                : SettingsManager.GlobalInstance.DailyLoyaltyBonus != Default.DailyLoyaltyBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyLoyaltyBonus)
                    : new CheatValue<int>(false, Default.DailyLoyaltyBonus);

        public static CheatValue<int> DailySecurityBonus =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.DailySecurityBonus != Default.DailySecurityBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.DailySecurityBonus)
                : SettingsManager.GlobalInstance.DailySecurityBonus != Default.DailySecurityBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailySecurityBonus)
                    : new CheatValue<int>(false, Default.DailySecurityBonus);

        public static CheatValue<int> DailyHearthsBonus =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.DailyHearthsBonus != Default.DailyHearthsBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.DailyHearthsBonus)
                : SettingsManager.GlobalInstance.DailyHearthsBonus != Default.DailyHearthsBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.DailyHearthsBonus)
                    : new CheatValue<int>(false, Default.DailyHearthsBonus);

        public static CheatValue<float> GarrisonWagesPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.GarrisonWagesPercentage != Default.GarrisonWagesPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.GarrisonWagesPercentage)
                : SettingsManager.GlobalInstance.GarrisonWagesPercentage != Default.GarrisonWagesPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.GarrisonWagesPercentage)
                    : new CheatValue<float>(false, Default.GarrisonWagesPercentage);

        public static CheatValue<bool> NeverRequireCivilianEquipment =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.NeverRequireCivilianEquipment != Default.NeverRequireCivilianEquipment
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NeverRequireCivilianEquipment)
                : SettingsManager.GlobalInstance.NeverRequireCivilianEquipment != Default.NeverRequireCivilianEquipment
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NeverRequireCivilianEquipment)
                    : new CheatValue<bool>(false, Default.NeverRequireCivilianEquipment);

        public static CheatValue<float> ConstructionPowerMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.ConstructionPowerMultiplier != Default.ConstructionPowerMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.ConstructionPowerMultiplier)
                : SettingsManager.GlobalInstance.ConstructionPowerMultiplier != Default.ConstructionPowerMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.ConstructionPowerMultiplier)
                    : new CheatValue<float>(false, Default.ConstructionPowerMultiplier);

        public static CheatValue<bool> NoBribeToEnterKeep =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.NoBribeToEnterKeep != Default.NoBribeToEnterKeep
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.NoBribeToEnterKeep)
                : SettingsManager.GlobalInstance.NoBribeToEnterKeep != Default.NoBribeToEnterKeep
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.NoBribeToEnterKeep)
                    : new CheatValue<bool>(false, Default.NoBribeToEnterKeep);

        public static CheatValue<bool> SettlementsNeverRebel =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.SettlementsNeverRebel != Default.SettlementsNeverRebel
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.SettlementsNeverRebel)
                : SettingsManager.GlobalInstance.SettlementsNeverRebel != Default.SettlementsNeverRebel
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.SettlementsNeverRebel)
                    : new CheatValue<bool>(false, Default.SettlementsNeverRebel);

        #endregion Settlements

        #region Smithing

        public static CheatValue<float> SmithingEnergyCostPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.SmithingEnergyCostPercentage != Default.SmithingEnergyCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.SmithingEnergyCostPercentage)
                : SettingsManager.GlobalInstance.SmithingEnergyCostPercentage != Default.SmithingEnergyCostPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.SmithingEnergyCostPercentage)
                    : new CheatValue<float>(false, Default.SmithingEnergyCostPercentage);

        public static CheatValue<bool> UnlockAllParts =>
            SettingsManager.IsPerSaveInstanceLoaded &&
            SettingsManager.PerSaveInstance.UnlockAllParts != Default.UnlockAllParts
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.UnlockAllParts)
                : SettingsManager.GlobalInstance.UnlockAllParts != Default.UnlockAllParts
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.UnlockAllParts)
                    : new CheatValue<bool>(false, Default.UnlockAllParts);

        public static CheatValue<float> SmithingDifficultyPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.SmithingDifficultyPercentage != Default.SmithingDifficultyPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.SmithingDifficultyPercentage)
                : SettingsManager.GlobalInstance.SmithingDifficultyPercentage != Default.SmithingDifficultyPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.SmithingDifficultyPercentage)
                    : new CheatValue<float>(false, Default.SmithingDifficultyPercentage);

        public static CheatValue<float> SmithingCostPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.SmithingCostPercentage != Default.SmithingCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.SmithingCostPercentage)
                : SettingsManager.GlobalInstance.SmithingCostPercentage != Default.SmithingCostPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.SmithingCostPercentage)
                    : new CheatValue<float>(false, Default.SmithingCostPercentage);

        public static CheatValue<int> CraftedWeaponHandlingBonus =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.CraftedWeaponHandlingBonus != Default.CraftedWeaponHandlingBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.CraftedWeaponHandlingBonus)
                : SettingsManager.GlobalInstance.CraftedWeaponHandlingBonus != Default.CraftedWeaponHandlingBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.CraftedWeaponHandlingBonus)
                    : new CheatValue<int>(false, Default.CraftedWeaponHandlingBonus);

        public static CheatValue<int> CraftedWeaponSwingDamageBonus =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.CraftedWeaponSwingDamageBonus != Default.CraftedWeaponSwingDamageBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.CraftedWeaponSwingDamageBonus)
                : SettingsManager.GlobalInstance.CraftedWeaponSwingDamageBonus != Default.CraftedWeaponSwingDamageBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.CraftedWeaponSwingDamageBonus)
                    : new CheatValue<int>(false, Default.CraftedWeaponSwingDamageBonus);

        public static CheatValue<int> CraftedWeaponSwingSpeedBonus =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.CraftedWeaponSwingSpeedBonus != Default.CraftedWeaponSwingSpeedBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.CraftedWeaponSwingSpeedBonus)
                : SettingsManager.GlobalInstance.CraftedWeaponSwingSpeedBonus != Default.CraftedWeaponSwingSpeedBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.CraftedWeaponSwingSpeedBonus)
                    : new CheatValue<int>(false, Default.CraftedWeaponSwingSpeedBonus);

        public static CheatValue<int> CraftedWeaponThrustDamageBonus =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.CraftedWeaponThrustDamageBonus != Default.CraftedWeaponThrustDamageBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.CraftedWeaponThrustDamageBonus)
                : SettingsManager.GlobalInstance.CraftedWeaponThrustDamageBonus != Default.CraftedWeaponThrustDamageBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.CraftedWeaponThrustDamageBonus)
                    : new CheatValue<int>(false, Default.CraftedWeaponThrustDamageBonus);

        public static CheatValue<int> CraftedWeaponThrustSpeedBonus =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.CraftedWeaponThrustSpeedBonus != Default.CraftedWeaponThrustSpeedBonus
                ? new CheatValue<int>(true, SettingsManager.PerSaveInstance.CraftedWeaponThrustSpeedBonus)
                : SettingsManager.GlobalInstance.CraftedWeaponThrustSpeedBonus != Default.CraftedWeaponThrustSpeedBonus
                    ? new CheatValue<int>(true, SettingsManager.GlobalInstance.CraftedWeaponThrustSpeedBonus)
                    : new CheatValue<int>(false, Default.CraftedWeaponThrustSpeedBonus);

        #endregion Smithing

        #region Workshops

        public static CheatValue<float> WorkshopBuyingCostPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.WorkshopBuyingCostPercentage != Default.WorkshopBuyingCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.WorkshopBuyingCostPercentage)
                : SettingsManager.GlobalInstance.WorkshopBuyingCostPercentage != Default.WorkshopBuyingCostPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.WorkshopBuyingCostPercentage)
                    : new CheatValue<float>(false, Default.WorkshopBuyingCostPercentage);

        public static CheatValue<float> WorkshopDailyExpensePercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.WorkshopDailyExpensePercentage != Default.WorkshopDailyExpensePercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.WorkshopDailyExpensePercentage)
                : SettingsManager.GlobalInstance.WorkshopDailyExpensePercentage != Default.WorkshopDailyExpensePercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.WorkshopDailyExpensePercentage)
                    : new CheatValue<float>(false, Default.WorkshopDailyExpensePercentage);

        public static CheatValue<float> WorkshopUpgradeCostPercentage =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.WorkshopUpgradeCostPercentage != Default.WorkshopUpgradeCostPercentage
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.WorkshopUpgradeCostPercentage)
                : SettingsManager.GlobalInstance.WorkshopUpgradeCostPercentage != Default.WorkshopUpgradeCostPercentage
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.WorkshopUpgradeCostPercentage)
                    : new CheatValue<float>(false, Default.WorkshopUpgradeCostPercentage);

        public static CheatValue<float> WorkshopSellingCostMultiplier =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.WorkshopSellingCostMultiplier != Default.WorkshopSellingCostMultiplier
                ? new CheatValue<float>(true, SettingsManager.PerSaveInstance.WorkshopSellingCostMultiplier)
                : SettingsManager.GlobalInstance.WorkshopSellingCostMultiplier != Default.WorkshopSellingCostMultiplier
                    ? new CheatValue<float>(true, SettingsManager.GlobalInstance.WorkshopSellingCostMultiplier)
                    : new CheatValue<float>(false, Default.WorkshopSellingCostMultiplier);

        public static CheatValue<bool> EveryoneBuysWorkshops =>
            SettingsManager.IsPerSaveInstanceLoaded && SettingsManager.PerSaveInstance.EveryoneBuysWorkshops != Default.EveryoneBuysWorkshops
                ? new CheatValue<bool>(true, SettingsManager.PerSaveInstance.EveryoneBuysWorkshops)
                : SettingsManager.GlobalInstance.EveryoneBuysWorkshops != Default.EveryoneBuysWorkshops
                    ? new CheatValue<bool>(true, SettingsManager.GlobalInstance.EveryoneBuysWorkshops)
                    : new CheatValue<bool>(false, Default.EveryoneBuysWorkshops);

        #endregion Workshops
    }
}
