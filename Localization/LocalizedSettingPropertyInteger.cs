using MCM.Abstractions.Settings.Definitions;

namespace BannerlordCheats.Localization
{
    public sealed class LocalizedSettingPropertyInteger : LocalizedSettingProperty, IPropertyDefinitionWithMinMax, IPropertyDefinitionWithFormat
    {
        public LocalizedSettingPropertyInteger(string settingName, int minValue, int maxValue) : base(settingName)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public string ValueFormat => "0";

        public decimal MinValue { get; }

        public decimal MaxValue { get; }
    }
}
