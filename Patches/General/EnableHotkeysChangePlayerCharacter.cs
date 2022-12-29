using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(EncyclopediaPageVM), "OnTick")]
    public static class EnableHotkeysChangePlayerCharacter
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(ref EncyclopediaPageVM __instance)
        {
            try
            {
                if (__instance is EncyclopediaHeroPageVM
                    && __instance.Obj is Hero hero
                    && SettingsManager.EnableHotkeys.Value)
                {
                    if (Keys.IsKeyPressed(InputKey.H, InputKey.LeftControl))
                    {
                        InformationManager.ShowInquiry(
                            new InquiryData(L10N.GetTextFormat("ChangePlayerMessageTitle", hero.Name),
                                L10N.GetText("ChangePlayerMessage"), true, true,
                                L10N.GetText("ChangePlayerConfirm"), L10N.GetText("Cancel"),
                                () => ChangePlayerCharacterAction.Apply(hero), null), true, true);
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysKillCharacter));
            }
        }
    }
}
