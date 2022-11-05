using System;
using System.Reflection;
using System.Text.RegularExpressions;
using BannerlordCheats.Localization;
using JetBrains.Annotations;
using MCM.Abstractions.Base.Global;
using TaleWorlds.Library;

namespace BannerlordCheats.Settings
{
    [UsedImplicitly]
    public class BannerlordCheatsGlobalSettings : AttributeGlobalSettings<BannerlordCheatsGlobalSettings>
    {
        private const string ModName = "ModName";
        private const string Understood = "Understood";
        private const string Global = "Global";

        public override string Id { get; } = $"BannerlordCheats_v{Assembly.GetExecutingAssembly().GetName().Version.Major}_Global";

        public override string DisplayName { get; }

        public BannerlordCheatsGlobalSettings()
        {
            string modName;
            string global;

            try { modName = L10N.GetText(BannerlordCheatsGlobalSettings.ModName); }
            catch { modName = "Cheats"; }

            try { global = L10N.GetText(BannerlordCheatsGlobalSettings.Global); }
            catch { global = "Global"; }

            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            version = Regex.Replace(version, @"\.0", string.Empty);
            if (!version.Contains(".")) {  version += ".0"; }

            this.DisplayName = $"{modName} {version} ({global})";
        }

        [UsedImplicitly]
        [LocalizedSettingPropertyButton(nameof(BannerlordCheatsGlobalSettings.IUnderstand), BannerlordCheatsGlobalSettings.Understood)]
        public Action IUnderstand { get; set; } = () => InformationManager.DisplayMessage(new InformationMessage(L10N.GetText("ThanksForReadingMessage")));
    }
}
