using MCM.Abstractions;

namespace BannerlordCheats.Localization
{
    public class LocalizedSettingPropertyButton : LocalizedSettingProperty, IPropertyDefinitionButton
    {
        public LocalizedSettingPropertyButton(string settingName, string buttonContentKey) : base(settingName)
        {
            this.Content = L10N.GetText(buttonContentKey);
        }

        public string Content { get; }
    }
}
