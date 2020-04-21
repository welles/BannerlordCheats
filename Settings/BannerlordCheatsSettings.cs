using MBOptionScreen.Attributes;
using MBOptionScreen.Settings;
using System.Reflection;

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
        [SettingProperty(displayName: "Enable Hotkeys", requireRestart: false, hintText: "Enable cheat hotkeys in inventory, character, etc. screens.")]
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

        #endregion

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
    }
}
