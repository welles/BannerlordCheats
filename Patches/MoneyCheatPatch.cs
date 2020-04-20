using BannerlordCheats.Extensions;
using HarmonyLib;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class MoneyCheatPatch
    {
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            if (ScreenManager.TopScreen is InventoryGauntletScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X))
            {
                Hero.MainHero.ChangeHeroGold(1000);

                InformationManager.DisplayMessage(new InformationMessage("Added 1000 gold.", Color.White));
            }
        }
    }
}
