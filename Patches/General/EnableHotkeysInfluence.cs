using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.ScreenSystem;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(GameManagerBase), nameof(GameManagerBase.OnTick))]
    public static class EnableHotkeysInfluence
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(
            ref float dt)
        {
            try
            {
                if (ScreenManager.TopScreen is GauntletClanScreen
                    && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X)
                    && SettingsManager.EnableHotkeys.Value)
                {
                    Hero.MainHero.AddInfluenceWithKingdom(1000);

                    Message.Show(L10N.GetText("AddInfluenceMessage"));
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysInfluence));
            }
        }
    }
}
