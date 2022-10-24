using MCM.Abstractions.Settings.Definitions;
using System;

namespace BannerlordCheats.Localization
{
    public sealed class LocalizedSettingPropertyFloatingInteger : LocalizedSettingProperty, IPropertyDefinitionWithMinMax, IPropertyDefinitionWithFormat
    {
        public LocalizedSettingPropertyFloatingInteger(string settingName, float minValue, float maxValue) : base(settingName)
        {
            MinValue = Convert.ToDecimal(minValue);
            MaxValue = Convert.ToDecimal(maxValue);
        }

        public string ValueFormat => "0.00";

        public decimal MinValue { get; }

        public decimal MaxValue { get; }
    }
}
