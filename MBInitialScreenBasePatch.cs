using System.IO;
using System.Reflection;
using BannerlordCheats.Localization;
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

        private static void CreateConfirmFile()
        {
            try
            {
                var confirmFileName = $"I Understand How The Cheats Work.txt";

                var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var confirmFilePath = Path.Combine(location, confirmFileName);

                File.Create(confirmFileName);
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
                var confirmFileName = $"I Understand How The Cheats Work.txt";

                var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var confirmFilePath = Path.Combine(location, confirmFileName);

                return File.Exists(confirmFilePath);
            }
            catch
            {
                return false;
            }
        }
    }
}
