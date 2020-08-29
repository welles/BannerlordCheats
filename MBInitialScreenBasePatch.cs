using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats
{
    [HarmonyPatch(typeof(MBInitialScreenBase), "OnInitialize")]
    public static class MBInitialScreenBasePatch
    {
        [HarmonyPostfix]
        public static void OnInitialize()
        {
            if (SubModule.ErrorFile != null)
            {
                InformationManager.DisplayMessage(new InformationMessage("Bannerlord Cheats could not load correctly!", Color.FromUint(16711680)));
                InformationManager.DisplayMessage(new InformationMessage($"Detailed error info has been saved in the file {SubModule.ErrorFile} in the Cheats mod folder.", Color.FromUint(16711680)));
                InformationManager.DisplayMessage(new InformationMessage("If possible please send this file to the mod author.", Color.FromUint(16711680)));
                InformationManager.DisplayMessage(new InformationMessage("You can still play the game, but some cheats may not work.", Color.FromUint(16711680)));
            }
        }
    }
}
