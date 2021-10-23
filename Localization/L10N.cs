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
            return L10N.Values[key];
        }
    }
}
