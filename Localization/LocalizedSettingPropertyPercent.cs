using MCM.Abstractions.Settings.Definitions;

namespace BannerlordCheats.Localization
{
    public sealed class LocalizedSettingPropertyPercent : LocalizedSettingProperty, IPropertyDefinitionWithMinMax, IPropertyDefinitionWithFormat
    {
        public LocalizedSettingPropertyPercent(string settingName, float defaultValue) : base(settingName, defaultValue) { }

        public string ValueFormat { get; } = "0.00\\%";

        public decimal MinValue { get; } = 0;

        public decimal MaxValue { get; } = 100;
    }
}
