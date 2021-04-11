using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using HarmonyLib;
using TaleWorlds.ModuleManager;
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
                Debugger.Break();

                try
                {
                    var errorFileName = $"Error-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt";

                    SubModule.ErrorFile = errorFileName;

                    var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    var errorFilePath = Path.Combine(location, errorFileName);

                    var errorMessage = new StringBuilder();

                    foreach (var module in ModuleHelper.GetModules())
                    {
                        errorMessage.AppendLine($"{module.Name} {module.Version}");
                    }

                    errorMessage.AppendLine();
                    errorMessage.AppendLine(e.ToString());

                    File.WriteAllText(errorFilePath, errorMessage.ToString());
                }
                catch
                {
                    // Not worth crashing for
                }
            }
        }
    }
}
