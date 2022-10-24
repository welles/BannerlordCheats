using MCM.Abstractions.Settings.Definitions;

namespace BannerlordCheats.Localization
{
    public sealed class LocalizedSettingPropertyPercent : LocalizedSettingProperty, IPropertyDefinitionWithMinMax, IPropertyDefinitionWithFormat
    {
        public LocalizedSettingPropertyPercent(string settingName) : base(settingName) { }

        public string ValueFormat => "0.00\\%";

        public decimal MinValue => 0;

        public decimal MaxValue => 100;
    }
}
