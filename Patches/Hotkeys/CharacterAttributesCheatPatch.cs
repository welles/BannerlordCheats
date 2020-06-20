using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class CharacterAttributesCheatPatch
    {
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.A) && BannerlordCheatsSettings.Instance.EnableHotkeys)
            {
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Control, 10);
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Cunning, 10);
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Endurance, 10);
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Intelligence, 10);
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Social, 10);
                Hero.MainHero.SetAttributeValue(CharacterAttributesEnum.Vigor, 10);

                var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

                charVM.RefreshValues();

                InformationManager.DisplayMessage(new InformationMessage($"Set attributes of {Hero.MainHero.Name} to 10.", Color.White));
            }
        }
    }
}
