using System;
using System.IO;
using System.Reflection;
using System.Text;
using HarmonyLib;
using TaleWorlds.DotNet;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats
{
    public class SubModule : MBSubModuleBase
    {
        public static string ErrorFile = null;

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
                try
                {
                    var errorFileName = $"Error-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt";

                    SubModule.ErrorFile = errorFileName;

                    var errorFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), errorFileName);

                    var errorMessage = new StringBuilder();
                    errorMessage.AppendLine("Installed Modules:");
                    errorMessage.AppendLine(Managed.GetModulesVersionStr());
                    errorMessage.AppendLine("Exception Message:");
                    errorMessage.AppendLine(e.ToString());

                    File.WriteAllText(errorFilePath, errorMessage.ToString());
                }
                catch { }
            }
        }
    }
}
