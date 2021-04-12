using MCM.Abstractions.Settings.Definitions;

namespace BannerlordCheats.Localization
{
    public sealed class LocalizedSettingPropertyInteger : LocalizedSettingProperty, IPropertyDefinitionWithMinMax, IPropertyDefinitionWithFormat
    {
        public LocalizedSettingPropertyInteger(string settingName, int minValue, int maxValue, int defaultValue) : base(settingName, defaultValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public string ValueFormat { get; } = "0";

        public decimal MinValue { get; }

        public decimal MaxValue { get; }
    }
}
