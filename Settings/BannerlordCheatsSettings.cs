using MBOptionScreen.Attributes;
using MBOptionScreen.Settings;

namespace BannerlordCheats.Settings
{
    public class BannerlordCheatsSettings : AttributeSettings<BannerlordCheatsSettings>
    {
        #region Base

        private const int SettingsVersion = 1;

        public override string Id { get; set; } = $"BannerlordCheats_v{SettingsVersion}";

        public override string ModuleFolderName => "Cheats";

        public override string ModName => "Cheats";

        #endregion Base

        #region Hotkeys

        [SettingPropertyGroup("Hotkeys")]
        [SettingProperty(displayName: "Enable Hotkeys", requireRestart: false, hintText: "Enable cheat hotkeys in inventory screen, party screen, clan screen etc.")]
        public bool EnableHotkeys { get; set; } = false;

        #endregion Hotkeys

        #region Map

        [SettingPropertyGroup("Map")]
        [SettingProperty(displayName: "Map Speed Factor", minValue: 1f, maxValue: 100f, editableMinValue: 1f, editableMaxValue: 100f, requireRestart: false, hintText: "Factor by which the speed of the player on the map is multiplied. A factor of 1 means default speed.")]
        public float MapSpeedFactor { get; set; } = 1.0f;

        [SettingPropertyGroup("Map")]
        [SettingProperty(displayName: "Map Visibility Factor", minValue: 1f, maxValue: 10f, editableMinValue: 1f, editableMaxValue: 10f, requireRestart: false, hintText: "Factor by which the visibility range of the player on the map is multiplied. A factor of 1 means default visibility. WARNING: Will negatively affect performance!")]
        public float MapVisibilityFactor { get; set; } = 1.0f;

        #endregion Map

        #region Combat

        [SettingPropertyGroup("Combat")]
        [SettingProperty(displayName: "Invincible", requireRestart: false, hintText: "Disables all damage to the player character.")]
        public bool Invincible { get; set; } = false;

        [SettingPropertyGroup("Combat")]
        [SettingProperty(displayName: "Damage Multiplier", minValue: 1, maxValue: 1000, editableMinValue: 1, editableMaxValue: 1000, requireRestart: false, hintText: "Factor by which the damage dealt by the player character in battle is multiplied. A factor of 1 means default damage.")]
        public int DamageMultiplier { get; set; } = 1;

        [SettingPropertyGroup("Combat")]
        [SettingProperty(displayName: "Renown Reward Multiplier", minValue: 1f, maxValue: 1000f, editableMinValue: 1f, editableMaxValue: 1000f, requireRestart: false, hintText: "Factor by which the renown reward after a won battle is multiplied. A factor of 1 means default renown.")]
        public float RenownRewardMultiplier { get; set; } = 1.0f;

        [SettingPropertyGroup("Combat")]
        [SettingProperty(displayName: "Influence Reward Multiplier", minValue: 1f, maxValue: 1000f, editableMinValue: 1f, editableMaxValue: 1000f, requireRestart: false, hintText: "Factor by which the influence reward after a won battle is multiplied. A factor of 1 means default influence.")]
        public float InfluenceRewardMultiplier { get; set; } = 1.0f;

        #endregion Combat

        #region Inventory

        [SettingPropertyGroup("Inventory")]
        [SettingProperty(displayName: "Extra Inventory Capacity", minValue: 0, maxValue: 1000000, editableMinValue: 0, editableMaxValue: 1000000, requireRestart: false, hintText: "Extra inventory capacity for the player party.")]
        public int ExtraInventoryCapacity { get; set; } = 0;

        #endregion Inventory

        #region Party

        [SettingPropertyGroup("Party")]
        [SettingProperty(displayName: "Extra Party Member Size", minValue: 0, maxValue: 10000, editableMinValue: 0, editableMaxValue: 10000, requireRestart: false, hintText: "Increase the maximum size for the player party.")]
        public int ExtraPartyMemberSize { get; set; } = 0;

        [SettingPropertyGroup("Party")]
        [SettingProperty(displayName: "Extra Party Prisoner Size", minValue: 0, maxValue: 10000, editableMinValue: 0, editableMaxValue: 10000, requireRestart: false, hintText: "Increase the maximum amount of prisoners travelling with the party.")]
        public int ExtraPartyPrisonerSize { get; set; } = 0;

        [SettingPropertyGroup("Party")]
        [SettingProperty(displayName: "Extra Party Morale", minValue: 0, maxValue: 100, editableMinValue: 0, editableMaxValue: 100, requireRestart: false, hintText: "Increase morale of the player party.")]
        public int ExtraPartyMorale { get; set; } = 0;

        #endregion

        #region Clan

        [SettingPropertyGroup("Clan")]
        [SettingProperty(displayName: "Extra Companion Limit", minValue: 0, maxValue: 100, editableMinValue: 0, editableMaxValue: 100, requireRestart: false, hintText: "Increase the maximum amount of companions in your clan.")]
        public int ExtraCompanionLimit { get; set; } = 0;

        [SettingPropertyGroup("Clan")]
        [SettingProperty(displayName: "Extra Clan Party Limit", minValue: 0, maxValue: 100, editableMinValue: 0, editableMaxValue: 100, requireRestart: false, hintText: "Increase the maximum amount of parties in your clan.")]
        public int ExtraClanPartyLimit { get; set; } = 0;

        #endregion Clan

        #region Experience

        [SettingPropertyGroup("Experience")]
        [SettingProperty(displayName: "Experience Multiplier", minValue: 1, maxValue: 10000, editableMinValue: 1, editableMaxValue: 10000, requireRestart: false, hintText: "Factor by which the experience gain of the player is multiplied. A factor of 1 means default experience.")]
        public float ExperienceMultiplier { get; set; } = 1.0f;

        [SettingPropertyGroup("Experience")]
        [SettingProperty(displayName: "Learning Rate Multiplier", minValue: 1, maxValue: 10000, editableMinValue: 1, editableMaxValue: 10000, requireRestart: false, hintText: "Factor by which the learning rate of the player is multiplied. A factor of 1 means default learning.")]
        public float LearningRateMultiplier { get; set; } = 1.0f;

        #endregion Experience

        #region Sieges

        [SettingPropertyGroup("Sieges")]
        [SettingProperty(displayName: "Siege Building Speed Multiplier", minValue: 1f, maxValue: 100f, editableMinValue: 1f, editableMaxValue: 100f, requireRestart: false, hintText: "Factor by which the speed of siege engine construction on the player party's side is multiplied. A factor of 1 means default build speed.")]
        public float SiegeBuildingSpeedMultiplier { get; set; } = 1.0f;

        #endregion Sieges

        #region Fiefs

        [SettingPropertyGroup("Fiefs")]
        [SettingProperty(displayName: "Construction Power Multiplier", minValue: 1, maxValue: 1000, editableMinValue: 1, editableMaxValue: 1000, requireRestart: false, hintText: "Factor by which the 'construction power' of player owned fiefs is multiplied. A factor of 1 means default construction power.")]
        public int ConstructionPowerMultiplier { get; set; } = 1;

        #endregion Fiefs
    }
}
