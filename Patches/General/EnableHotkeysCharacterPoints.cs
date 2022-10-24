using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(GameManagerBase), nameof(GameManagerBase.OnTick))]
    public static class EnableHotkeysCharacterPoints
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
                if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.F))
                {
                    var charVm = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

                    var currentHero = charVm.CurrentCharacter.Hero;

                    currentHero.HeroDeveloper.UnspentFocusPoints++;

                    charVm.CurrentCharacter.UnspentCharacterPoints++;

                    var message = string.Format(L10N.GetText("AddUnspentFocusPointMessage"), currentHero.Name);

                    Message.Show(message);
                }
                else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.G))
                {
                    var charVm = ScreenManager.TopScreen.GetViewModel<CharacterDeveloperVM>();

                    var currentHero = charVm.CurrentCharacter.Hero;

                    currentHero.HeroDeveloper.UnspentAttributePoints++;

                    charVm.CurrentCharacter.UnspentAttributePoints++;

                    var message = string.Format(L10N.GetText("AddUnspentAttributePointMessage"), currentHero.Name);

                    Message.Show(message);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysCharacterPoints));
            }
        }
    }
}
