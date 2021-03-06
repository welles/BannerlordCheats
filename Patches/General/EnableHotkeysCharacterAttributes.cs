﻿using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox.GauntletUI;
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
                && BannerlordCheatsSettings.Instance?.EnableHotkeys == true)
            {
                if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.A))
                {
                    var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

                    var currentHero = charVM.CurrentCharacter.Hero;

                    currentHero.SetAttributeValue(CharacterAttributesEnum.Control, 10);
                    currentHero.SetAttributeValue(CharacterAttributesEnum.Cunning, 10);
                    currentHero.SetAttributeValue(CharacterAttributesEnum.Endurance, 10);
                    currentHero.SetAttributeValue(CharacterAttributesEnum.Intelligence, 10);
                    currentHero.SetAttributeValue(CharacterAttributesEnum.Social, 10);
                    currentHero.SetAttributeValue(CharacterAttributesEnum.Vigor, 10);

                    charVM.RefreshValues();

                    var message = string.Format(L10N.GetText("SetAllAttributesMessage"), currentHero.Name);

                    InformationManager.DisplayMessage(new InformationMessage(message, Color.White));
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D1))
                {
                    EnableHotkeysCharacterAttributes.AddPoint(CharacterAttributesEnum.Vigor);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D2))
                {
                    EnableHotkeysCharacterAttributes.AddPoint(CharacterAttributesEnum.Control);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D3))
                {
                    EnableHotkeysCharacterAttributes.AddPoint(CharacterAttributesEnum.Endurance);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D4))
                {
                    EnableHotkeysCharacterAttributes.AddPoint(CharacterAttributesEnum.Cunning);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D5))
                {
                    EnableHotkeysCharacterAttributes.AddPoint(CharacterAttributesEnum.Social);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.D6))
                {
                    EnableHotkeysCharacterAttributes.AddPoint(CharacterAttributesEnum.Intelligence);
                }
            }
        }

        private static void AddPoint(CharacterAttributesEnum type)
        {
            var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

            var currentHero = charVM.CurrentCharacter.Hero;

            var oldValue = currentHero.GetAttributeValue(type);

            if (oldValue >= 10) { return; }

            currentHero.SetAttributeValue(type, oldValue + 1);

            charVM.RefreshValues();

            var message = string.Format(L10N.GetText("AddAttributePointMessage"), Enum.GetName(typeof(CharacterAttributesEnum), type), currentHero.Name);

            InformationManager.DisplayMessage(new InformationMessage(message, Color.White));
        }
    }
}
