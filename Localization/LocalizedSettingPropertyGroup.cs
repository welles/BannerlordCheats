using System;
using MCM.Abstractions;

namespace BannerlordCheats.Localization
{
    public class LocalizedSettingPropertyGroup : Attribute, IPropertyGroupDefinition
    {
        public LocalizedSettingPropertyGroup(string groupName)
        {
            try
            {
                this.GroupName = L10N.GetText(groupName + "_GroupName");
            }
            catch
            {
                this.GroupName = groupName;
            }
        }

        public string GroupName { get; }

        public int GroupOrder { get; }
    }
}
