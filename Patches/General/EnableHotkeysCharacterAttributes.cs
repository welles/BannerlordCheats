using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
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

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class EnableHotkeysCharacterAttributes
    {
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.EnableHotkeys, out var enableHotkeys)
                && enableHotkeys)
            {
                if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.A))
                {
                    var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

                    var currentHero = charVM.CurrentCharacter.Hero;

                    CharacterAttributesCheatPatch.SetMaximum(currentHero, DefaultCharacterAttributes.Control);
                    CharacterAttributesCheatPatch.SetMaximum(currentHero, DefaultCharacterAttributes.Cunning);
                    CharacterAttributesCheatPatch.SetMaximum(currentHero, DefaultCharacterAttributes.Endurance);
                    CharacterAttributesCheatPatch.SetMaximum(currentHero, DefaultCharacterAttributes.Intelligence);
                    CharacterAttributesCheatPatch.SetMaximum(currentHero, DefaultCharacterAttributes.Social);
                    CharacterAttributesCheatPatch.SetMaximum(currentHero, DefaultCharacterAttributes.Vigor);

                    charVM.RefreshValues();

                    var message = string.Format(L10N.GetText("SetAllAttributesMessage"), currentHero.Name);

                    InformationManager.DisplayMessage(new InformationMessage(message, Color.White));
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D1))
                {
                    CharacterAttributesCheatPatch.AddPoint(DefaultCharacterAttributes.Vigor);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D2))
                {
                    CharacterAttributesCheatPatch.AddPoint(DefaultCharacterAttributes.Control);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D3))
                {
                    CharacterAttributesCheatPatch.AddPoint(DefaultCharacterAttributes.Endurance);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D4))
                {
                    CharacterAttributesCheatPatch.AddPoint(DefaultCharacterAttributes.Cunning);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D5))
                {
                    CharacterAttributesCheatPatch.AddPoint(DefaultCharacterAttributes.Social);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D6))
                {
                    CharacterAttributesCheatPatch.AddPoint(DefaultCharacterAttributes.Intelligence);
                }
            }
        }

        private static void SetMaximum(Hero hero, CharacterAttribute attribute)
        {
            var changeAmount = 10 - hero.GetAttributeValue(attribute);

            hero.HeroDeveloper.AddAttribute(attribute, changeAmount, false);
        }

        private static void AddPoint(CharacterAttribute attribute)
        {
            var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

            var currentHero = charVM.CurrentCharacter.Hero;

            var oldValue = currentHero.GetAttributeValue(attribute);

            if (oldValue >= 10) { return; }

            currentHero.HeroDeveloper.AddAttribute(attribute, 1, false);

            charVM.RefreshValues();

            var message = string.Format(L10N.GetText("AddAttributePointMessage"), attribute.Name, currentHero.Name);

            InformationManager.DisplayMessage(new InformationMessage(message, Color.White));
        }
    }
}
