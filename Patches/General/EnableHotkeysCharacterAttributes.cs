﻿using System;
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
                if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen
                    && SettingsManager.EnableHotkeys.Value)
                {
                    if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.A))
                    {
                        var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

                        var currentHero = charVM.CurrentCharacter.Hero;

                        EnableHotkeysCharacterAttributes.SetMaximum(currentHero, DefaultCharacterAttributes.Control);
                        EnableHotkeysCharacterAttributes.SetMaximum(currentHero, DefaultCharacterAttributes.Cunning);
                        EnableHotkeysCharacterAttributes.SetMaximum(currentHero, DefaultCharacterAttributes.Endurance);
                        EnableHotkeysCharacterAttributes.SetMaximum(currentHero, DefaultCharacterAttributes.Intelligence);
                        EnableHotkeysCharacterAttributes.SetMaximum(currentHero, DefaultCharacterAttributes.Social);
                        EnableHotkeysCharacterAttributes.SetMaximum(currentHero, DefaultCharacterAttributes.Vigor);

                        charVM.RefreshValues();

                        var message = string.Format(L10N.GetText("SetAllAttributesMessage"), currentHero.Name);

                        Message.Show(message);
                    }
                    else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D1))
                    {
                        EnableHotkeysCharacterAttributes.AddPoint(DefaultCharacterAttributes.Vigor);
                    }
                    else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D2))
                    {
                        EnableHotkeysCharacterAttributes.AddPoint(DefaultCharacterAttributes.Control);
                    }
                    else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D3))
                    {
                        EnableHotkeysCharacterAttributes.AddPoint(DefaultCharacterAttributes.Endurance);
                    }
                    else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D4))
                    {
                        EnableHotkeysCharacterAttributes.AddPoint(DefaultCharacterAttributes.Cunning);
                    }
                    else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D5))
                    {
                        EnableHotkeysCharacterAttributes.AddPoint(DefaultCharacterAttributes.Social);
                    }
                    else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D6))
                    {
                        EnableHotkeysCharacterAttributes.AddPoint(DefaultCharacterAttributes.Intelligence);
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysCharacterAttributes));
            }
        }

        private static void SetMaximum(Hero hero, CharacterAttribute attribute)
        {
            var changeAmount = Campaign.Current.Models.CharacterDevelopmentModel.MaxAttribute - hero.GetAttributeValue(attribute);

            hero.HeroDeveloper.AddAttribute(attribute, changeAmount, false);
        }

        private static void AddPoint(CharacterAttribute attribute)
        {
            var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

            var currentHero = charVM.CurrentCharacter.Hero;

            var oldValue = currentHero.GetAttributeValue(attribute);

            if (oldValue >= Campaign.Current.Models.CharacterDevelopmentModel.MaxAttribute) { return; }

            currentHero.HeroDeveloper.AddAttribute(attribute, 1, false);

            charVM.RefreshValues();

            var message = string.Format(L10N.GetText("AddAttributePointMessage"), attribute.Name, currentHero.Name);

            Message.Show(message);
        }
    }
}
