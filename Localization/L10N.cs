using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace BannerlordCheats.Localization
{
    public static class L10N
    {
        private static Dictionary<string, string> Values;

        static L10N()
        {
            L10N.Values = new Dictionary<string, string>();

            var xmlLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "L10N.resx");

            var document = XDocument.Load(xmlLocation);

            var root = document.Element("root");

            var entries = root.Descendants("data");

            foreach (var entry in entries)
            {
                var key = entry.Attribute("name").Value;
                var value = entry.Element("value").Value;

                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    L10N.Values.Add(key, value);
                }
            }
        }

        public static string GetText(string key)
        {
            return L10N.Values.TryGetValue(key, out var text) ? text : key;
        }

        public static string GetTextFormat(string key, params object[] formatValues)
        {
            var found = L10N.Values.TryGetValue(key, out var text);

            if (!found)
            {
                return key;
            }

            for (int i = 0; i < formatValues.Length; i++)
            {
                text = text.Replace($"{{{i}}}", formatValues[i].ToString());
            }

            return text;
        }

        public static class Keys
        {
            public const string Global = "Global";
            public const string ModName = "ModName";
            public const string CombatPlayerGroupName = "Combat_Player";
            public const string CombatPartyGroupName = "Combat_Party";
            public const string CombatAlliesGroupName = "Combat_Allies";
            public const string CombatEnemiesGroupName = "Combat_Enemies";
            public const string CombatMiscGroupName = "Combat_Misc";
            public const string GeneralGroupName = "General";
            public const string MapGroupName = "Map";
            public const string InventoryGroupName = "Inventory";
            public const string PartyGroupName = "Party";
            public const string ClanGroupName = "Clan";
            public const string KingdomGroupName = "Kingdom";
            public const string ExperienceGroupName = "Experience";
            public const string SiegesGroupName = "Sieges";
            public const string ArmyGroupName = "Army";
            public const string SmithingGroupName = "Smithing";
            public const string SettlementsGroupName = "Settlements";
            public const string CharactersGroupName = "Characters";
            public const string WorkshopsGroupName = "Workshops";
        }
    }
}
