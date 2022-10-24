using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(GameManagerBase), nameof(GameManagerBase.OnTick))]
    public static class EnableHotkeysCharacterAttributes
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(
            ref float dt)
        {
            try
            {
                if (!(ScreenManager.TopScreen is GauntletCharacterDeveloperScreen)
                    || BannerlordCheatsSettings.Instance?.EnableHotkeys != true) return;
                if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.A))
                {
                    var charVm = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

                    var currentHero = charVm.CurrentCharacter.Hero;

                    SetMaximum(currentHero, DefaultCharacterAttributes.Control);
                    SetMaximum(currentHero, DefaultCharacterAttributes.Cunning);
                    SetMaximum(currentHero, DefaultCharacterAttributes.Endurance);
                    SetMaximum(currentHero, DefaultCharacterAttributes.Intelligence);
                    SetMaximum(currentHero, DefaultCharacterAttributes.Social);
                    SetMaximum(currentHero, DefaultCharacterAttributes.Vigor);

                    charVm.RefreshValues();

                    var message = string.Format(L10N.GetText("SetAllAttributesMessage"), currentHero.Name);

                    Message.Show(message);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D1))
                {
                    AddPoint(DefaultCharacterAttributes.Vigor);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D2))
                {
                    AddPoint(DefaultCharacterAttributes.Control);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D3))
                {
                    AddPoint(DefaultCharacterAttributes.Endurance);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D4))
                {
                    AddPoint(DefaultCharacterAttributes.Cunning);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D5))
                {
                    AddPoint(DefaultCharacterAttributes.Social);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D6))
                {
                    AddPoint(DefaultCharacterAttributes.Intelligence);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysCharacterAttributes));
            }
        }

        private static void SetMaximum(Hero hero, CharacterAttribute attribute)
        {
            var changeAmount = 10 - hero.GetAttributeValue(attribute);

            hero.HeroDeveloper.AddAttribute(attribute, changeAmount, false);
        }

        private static void AddPoint(CharacterAttribute attribute)
        {
            var charVm = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

            var currentHero = charVm.CurrentCharacter.Hero;

            var oldValue = currentHero.GetAttributeValue(attribute);

            if (oldValue >= 10) { return; }

            currentHero.HeroDeveloper.AddAttribute(attribute, 1, false);

            charVm.RefreshValues();

            var message = string.Format(L10N.GetText("AddAttributePointMessage"), attribute.Name, currentHero.Name);

            Message.Show(message);
        }
    }
}
