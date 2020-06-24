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

            var xmlLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "L10N.xml");

            var document = XDocument.Load(xmlLocation);

            var data = document.Element("data");

            var entries = data.Descendants();

            foreach (var entry in entries)
            {
                var key = entry.Attribute("key").Value;
                var value = entry.Value;

                if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
                {
                    L10N.Values.Add(key, value);
                }
            }
        }

        public static string GetText(string key)
        {
            return L10N.Values[key];
        }
    }
}
