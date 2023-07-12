using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(EncyclopediaPageVM), "OnTick")]
    public static class EnableHotkeysTransferSettlement
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(ref EncyclopediaPageVM __instance)
        {
            try
            {
                if (__instance is EncyclopediaSettlementPageVM
                    && __instance.Obj is Settlement settlement
                    && (settlement.IsCastle || settlement.IsTown)
                    && SettingsManager.EnableHotkeys.Value)
                {
                    if (Keys.IsKeyPressed(InputKey.H, InputKey.LeftControl))
                    {
                        InformationManager.ShowInquiry(
                            new InquiryData(L10N.GetTextFormat("TransferSettlementMessageTitle", settlement.Name),
                                L10N.GetText("TransferSettlementMessage"), true, true,
                                L10N.GetText("TransferSettlementConfirm"), L10N.GetText("Cancel"),
                                () => ChangeOwnerOfSettlementAction.ApplyByDefault(Hero.MainHero, settlement), null), true, true);
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysTransferSettlement));
            }
        }
    }
}
