using MCM.Abstractions.Settings.Definitions;

namespace BannerlordCheats.Localization
{
    public sealed class LocalizedSettingPropertyBool : LocalizedSettingProperty, IPropertyDefinitionBool
    {
        public LocalizedSettingPropertyBool(string settingName) : base(settingName) { }
    }
}
