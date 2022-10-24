using MCM.Abstractions.Settings.Definitions;
using System;

namespace BannerlordCheats.Localization
{
    public abstract class LocalizedSettingProperty : Attribute, IPropertyDefinitionBase
    {
        protected LocalizedSettingProperty(string settingName)
        {
            try
            {
                DisplayName = L10N.GetText(settingName + "_Name");
                HintText = L10N.GetText(settingName + "_Desc");
            }
            catch
            {
                DisplayName = settingName;
                HintText = "ERROR: Could not load description from localization resource.";
            }
        }

        public string DisplayName { get; }

        public int Order => -1;

        public bool RequireRestart => false;

        public string HintText { get; }
    }
}
