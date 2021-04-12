using MCM.Abstractions.Settings.Definitions;
using System;

namespace BannerlordCheats.Localization
{
    public abstract class LocalizedSettingProperty : Attribute, IPropertyDefinitionBase
    {
        public LocalizedSettingProperty(string settingName, object defaultValue)
        {
            this.DefaultValue = defaultValue;

            try
            {
                this.DisplayName = L10N.GetText(settingName + "_Name");
                this.HintText = L10N.GetText(settingName + "_Desc");
            }
            catch
            {
                this.DisplayName = settingName;
                this.HintText = "ERROR: Could not load description from localization resource.";
            }
        }

        public string DisplayName { get; }

        public int Order { get; } = -1;

        public bool RequireRestart { get; } = false;

        public string HintText { get; }

        public object DefaultValue { get; }
    }
}
