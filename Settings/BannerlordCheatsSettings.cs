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

        #region Map

        [SettingPropertyGroup("Map")]
        [SettingProperty(displayName: "Map Speed Factor", minValue: 1f, maxValue: 100f, editableMinValue: 1f, editableMaxValue: 100f, requireRestart: false, hintText: "Factor by which the speed of the player on the map is multiplied. A factor of 1 means default speed.")]
        public float MapSpeedFactor { get; set; } = 1.0f;

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

        #region Experience

        [SettingPropertyGroup("Experience")]
        [SettingProperty(displayName: "Experience Multiplier", minValue: 1, maxValue: 10000, editableMinValue: 1, editableMaxValue: 10000, requireRestart: false, hintText: "Factor by which the experience gain of the player is multiplied. A factor of 1 means default experience.")]
        public float ExperienceMultiplier { get; set; } = 1.0f;

        #endregion Experience
    }
}
