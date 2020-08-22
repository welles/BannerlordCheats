using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            var harmony = new Harmony("BannerlordCheats");

            harmony.PatchAll();
        }
    }
}
