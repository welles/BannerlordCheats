using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
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
        private static bool PatchesApplied = false;

        public override void OnInitialState()
        {
            base.OnInitialState();

            if (!SubModule.ConfirmFileExists())
            {
                InformationManager.ShowInquiry(new InquiryData(
                    L10N.GetText("ModName"),
                    L10N.GetText("ModWarningMessage"),
                    true,
                    false,
                    L10N.GetText("ModWarningMessageConfirm"),
                    null,
                    SubModule.CreateConfirmFile,
                    null));
            }
        }

        public override void OnGameInitializationFinished(Game game)
        {
            base.OnGameInitializationFinished(game);

            if (!(game.GameType is Campaign) || SubModule.PatchesApplied)
            {
                return;
            }

            try
            {
                var harmony = new Harmony("BannerlordCheats");

                harmony.PatchAll();

                SubModule.PatchesApplied = true;
            }
            catch (Exception e)
            {
                Debugger.Break();

                try
                {
                    var errorFilePath = SubModule.CreateErrorFile(e);

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

        private static string CreateErrorFile(Exception e)
        {
            var errorFileName = $"Error-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt";

            var assemblyLocation = Assembly.GetAssembly(typeof(BannerlordCheatsSettings)).Location;

            var location = Path.GetDirectoryName(assemblyLocation);

            var errorFilePath = Path.Combine(location, errorFileName);

            var errorMessage = new StringBuilder();

            foreach (var module in ModuleHelper.GetModules())
            {
                errorMessage.AppendLine($"{module.Name} {module.Version}");
            }

            errorMessage.AppendLine();
            errorMessage.AppendLine(e.ToString());

            File.WriteAllText(errorFilePath, errorMessage.ToString());

            return errorFilePath;
        }

        private static string ConfirmFilePath
        {
            get
            {
                var confirmFileName = "I Understand How The Cheats Work.txt";

                var assemblyLocation = Assembly.GetAssembly(typeof(BannerlordCheatsSettings)).Location;

                var location = Path.GetDirectoryName(assemblyLocation);

                var confirmFilePath = Path.Combine(location, confirmFileName);

                return confirmFilePath;
            }
        }

        private static void CreateConfirmFile()
        {
            try
            {
                File.Create(SubModule.ConfirmFilePath);
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
                return File.Exists(SubModule.ConfirmFilePath);
            }
            catch
            {
                return false;
            }
        }
    }
}
