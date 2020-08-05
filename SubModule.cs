using HarmonyLib;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            try
            {
                base.OnSubModuleLoad();

                var harmony = new Harmony("BannerlordCheats");

                harmony.PatchAll();
            }
            catch (Exception e)
            {
                var text = new StringBuilder();
                text.AppendLine("Bannerlord Cheats could not load!");
                text.AppendLine();
                text.AppendLine("Please check if this game version is compatible with the mod.");
                text.AppendLine();
                text.AppendLine("If it is, please post the following error message to the mod page comments. (Click the OK button below to copy the error message to the clipboard and open the mod page.)");
                text.AppendLine();
                text.AppendLine("-------------------------------------------------------------------------------");
                text.AppendLine();
                text.AppendLine(e.ToString());

                var result = MessageBox.Show(text.ToString(), "Bannerlord Cheats could not load!", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.OK);

                if (result == MessageBoxResult.OK)
                {
                    try
                    {
                        Clipboard.Clear();
                        Clipboard.SetText(e.ToString());

                        Process.Start("https://www.nexusmods.com/mountandblade2bannerlord/mods/1839?tab=posts");
                    }
                    catch { }
                }

                throw;
            }
        }
    }
}
