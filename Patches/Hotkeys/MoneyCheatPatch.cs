using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
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
            if (ScreenManager.TopScreen is InventoryGauntletScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X) && BannerlordCheatsSettings.Instance.EnableHotkeys)
            {
                Hero.MainHero.ChangeHeroGold(1000);

                InformationManager.DisplayMessage(new InformationMessage(L10N.GetText("AddGoldMessage"), Color.White));
            }
        }
    }
}
