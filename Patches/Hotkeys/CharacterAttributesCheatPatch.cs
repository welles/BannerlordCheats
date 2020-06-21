using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox.GauntletUI;
using System;
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

            if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D1) && BannerlordCheatsSettings.Instance.EnableHotkeys)
            {
                AddPoint(CharacterAttributesEnum.Vigor);
            }

            if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D2) && BannerlordCheatsSettings.Instance.EnableHotkeys)
            {
                AddPoint(CharacterAttributesEnum.Control);
            }

            if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D3) && BannerlordCheatsSettings.Instance.EnableHotkeys)
            {
                AddPoint(CharacterAttributesEnum.Endurance);
            }

            if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D4) && BannerlordCheatsSettings.Instance.EnableHotkeys)
            {
                AddPoint(CharacterAttributesEnum.Cunning);
            }

            if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D5) && BannerlordCheatsSettings.Instance.EnableHotkeys)
            {
                AddPoint(CharacterAttributesEnum.Social);
            }

            if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D6) && BannerlordCheatsSettings.Instance.EnableHotkeys)
            {
                AddPoint(CharacterAttributesEnum.Intelligence);
            }
        }

        private static void AddPoint(CharacterAttributesEnum type)
        {
            var oldValue = Hero.MainHero.GetAttributeValue(type);

            if (oldValue >= 10) { return; }

            Hero.MainHero.SetAttributeValue(type, oldValue + 1);

            var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

            charVM.RefreshValues();

            InformationManager.DisplayMessage(new InformationMessage($"Added 1 point to {Enum.GetName(typeof(CharacterAttributesEnum), type)}.", Color.White));
        }
    }
}
