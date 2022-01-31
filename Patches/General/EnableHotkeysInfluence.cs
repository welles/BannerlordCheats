using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class EnableHotkeysInfluence
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            try
            {
                if (ScreenManager.TopScreen is GauntletClanScreen
                    && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X)
                    && BannerlordCheatsSettings.Instance?.EnableHotkeys == true)
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
