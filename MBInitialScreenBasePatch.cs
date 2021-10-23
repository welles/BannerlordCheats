using System.IO;
using System.Reflection;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats
{
    [HarmonyPatch(typeof(MBInitialScreenBase), "OnInitialize")]
    public static class MBInitialScreenBasePatch
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnInitialize()
        {
            if (SubModule.ErrorFile != null)
            {
                InformationManager.ShowInquiry(new InquiryData(
                    L10N.GetText("ModFailedLoadWarningTitle"),
                    L10N.GetTextFormat("ModFailedLoadWarningMessage", SubModule.ErrorFile),
                    true,
                    false,
                    L10N.GetText("ModWarningMessageConfirm"),
                    null,
                    null,
                    null));
            }
            else if (!ConfirmFileExists())
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
