using MCM.Abstractions;

namespace BannerlordCheats.Localization
{
    public class LocalizedSettingPropertyDropdown : LocalizedSettingProperty, IPropertyDefinitionDropdown
    {
        public LocalizedSettingPropertyDropdown(string settingName, int defaultIndex) : base(settingName)
        {
            this.SelectedIndex = defaultIndex;
        }

        public LocalizedSettingPropertyDropdown(string settingName, object defaultIndex) : base(settingName)
        {
            this.SelectedIndex = (int) defaultIndex;
        }

        public int SelectedIndex { get; }
    }
}