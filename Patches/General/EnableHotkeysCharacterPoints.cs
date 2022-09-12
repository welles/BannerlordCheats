using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class EnableHotkeysCharacterPoints
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            try
            {
                if (ScreenManager.TopScreen is GauntletCharacterDeveloperScreen
                    && BannerlordCheatsSettings.Instance?.EnableHotkeys == true)
                {
                    if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.F))
                    {
                        var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

                        var currentHero = charVM.CurrentCharacter.Hero;

                        currentHero.HeroDeveloper.UnspentFocusPoints++;

                        charVM.CurrentCharacter.UnspentCharacterPoints++;

                        var message = string.Format(L10N.GetText("AddUnspentFocusPointMessage"), currentHero.Name);

                        Message.Show(message);
                    }
                    else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.G))
                    {
                        var charVM = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

                        var currentHero = charVM.CurrentCharacter.Hero;

                        currentHero.HeroDeveloper.UnspentAttributePoints++;

                        charVM.CurrentCharacter.UnspentAttributePoints++;

                        var message = string.Format(L10N.GetText("AddUnspentAttributePointMessage"), currentHero.Name);

                        Message.Show(message);
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysCharacterPoints));
            }
        }
    }
}
