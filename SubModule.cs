using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats
{
    [UsedImplicitly]
    public class SubModule : MBSubModuleBase
    {
        private static bool _patchesApplied;

        public override void OnInitialState()
        {
            base.OnInitialState();

            if (!ConfirmFileExists())
            {
                InformationManager.ShowInquiry(new InquiryData(
                    L10N.GetText("ModName"),
                    L10N.GetText("ModWarningMessage"),
                    true,
                    false,
                    L10N.GetText("ModWarningMessageConfirm"),
                    null,
                    CreateConfirmFile,
                    null));
            }
        }

        public override void OnGameInitializationFinished(Game game)
        {
            base.OnGameInitializationFinished(game);

            if (!(game.GameType is Campaign) || _patchesApplied)
            {
                return;
            }

            try
            {
                var harmony = new Harmony("BannerlordCheats");

                harmony.PatchAll();

                _patchesApplied = true;
            }
            catch (Exception e)
            {
                Debugger.Break();

                try
                {
                    var errorFilePath = CreateErrorFile(e);

                    InformationManager.ShowInquiry(new InquiryData(
                        L10N.GetText("ModFailedLoadWarningTitle"),
                        L10N.GetTextFormat("ModFailedLoadWarningMessage", errorFilePath),
                        true,
                        false,
                        L10N.GetText("ModWarningMessageConfirm"),
                        null,
                        null,
                        null));
                }
                catch
                {
                    // Not worth crashing for
                }
            }
        }

        internal static void LogError(Exception e, Type type)
        {
            string errorFilePath;

            try
            {
                errorFilePath = CreateErrorFile(e, type);
            }
            catch
            {
                return;
            }

            try
            {
                InformationManager.ShowInquiry(new InquiryData(
                    L10N.GetText("ModExceptionTitle"),
                    L10N.GetTextFormat("ModExceptionMessage", errorFilePath),
                    true,
                    false,
                    L10N.GetText("ModWarningMessageConfirm"),
                    null,
                    null,
                    null));
            }
            catch
            {
                try
                {
                    Message.Show(L10N.GetTextFormat("ModExceptionMessage", errorFilePath), Colors.Red);
                }
                catch
                {
                    // If this fails everything is lost anyways
                }
            }
        }

        private static string CreateErrorFile(Exception e, Type type = null)
        {
            var errorFileName = $"Error-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt";

            var assemblyLocation = Assembly.GetAssembly(typeof(BannerlordCheatsSettings)).Location;

            var location = Path.GetDirectoryName(assemblyLocation);

            if (location == null) return null;
            var errorFilePath = Path.Combine(location, errorFileName);

            var errorMessage = new StringBuilder();

            errorMessage.AppendLine("Thanks a lot for helping to improve this mod!");
            errorMessage.AppendLine(
                "You could drop the contents of this file into https://pastebin.com/ and post a link to the file");
            errorMessage.AppendLine(
                "in the NexusMods posts page at https://www.nexusmods.com/mountandblade2bannerlord/mods/1839?tab=posts");

            errorMessage.AppendLine();
            errorMessage.AppendLine("Modules:");

            foreach (var module in ModuleHelper.GetModules())
            {
                errorMessage.AppendLine($"{module.Name} {module.Version}");
            }

            if (type != null)
            {
                errorMessage.AppendLine();
                errorMessage.AppendLine("Harmony Patch:");

                var patch = type.GetCustomAttribute<HarmonyPatch>();

                errorMessage.AppendLine($"Type: {type.FullName}");
                errorMessage.AppendLine($"Declaring Type: {patch.info.declaringType.FullName}");
                errorMessage.AppendLine($"Method: {patch.info.methodName}");
            }

            errorMessage.AppendLine();
            errorMessage.AppendLine("Exception:");
            errorMessage.AppendLine(e.ToString());

            File.WriteAllText(errorFilePath, errorMessage.ToString());

            return errorFilePath;
        }

        private static string ConfirmFilePath
        {
            get
            {
                const string confirmFileName = "I Understand How The Cheats Work.txt";

                var assemblyLocation = Assembly.GetAssembly(typeof(BannerlordCheatsSettings)).Location;

                var location = Path.GetDirectoryName(assemblyLocation);

                if (location == null) return null;
                var confirmFilePath = Path.Combine(location, confirmFileName);

                return confirmFilePath;
            }
        }

        private static void CreateConfirmFile()
        {
            try
            {
                File.Create(ConfirmFilePath);
            }
            catch
            {
                // Not worth crashing for
            }
        }

        private static bool ConfirmFileExists()
        {
            try
            {
                return File.Exists(ConfirmFilePath);
            }
            catch
            {
                return false;
            }
        }
    }
}