using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(EncyclopediaPageVM), "OnTick")]
    public static class EnableHotkeysKillCharacter
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(ref EncyclopediaPageVM __instance)
        {
            try
            {
                if (__instance is EncyclopediaHeroPageVM
                    && __instance.Obj is Hero hero
                    && BannerlordCheatsSettings.Instance?.EnableHotkeys == true)
                {
                    if (Keys.IsKeyPressed(InputKey.X, InputKey.LeftControl))
                    {
                        InformationManager.ShowInquiry(
                            new InquiryData(L10N.GetTextFormat("KillCharacterMessageTitle", hero.Name),
                                L10N.GetText("KillCharacterMessage"), true, true,
                                L10N.GetText("KillCharacterConfirm"), L10N.GetText("Cancel"),
                                () => KillCharacterAction.ApplyByMurder(hero), null), true, true);
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
