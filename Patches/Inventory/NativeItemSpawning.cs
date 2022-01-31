using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace BannerlordCheats.Patches.Inventory
{
    [HarmonyPatch(typeof(InventoryLogic), nameof(InventoryLogic.Initialize), typeof(ItemRoster), typeof(MobileParty), typeof(bool), typeof(bool), typeof(CharacterObject), typeof(InventoryManager.InventoryCategoryType), typeof(IMarketData), typeof(bool), typeof(TextObject))]
    public static class NativeItemSpawning
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void Initialize(
            ref ItemRoster leftItemRoster,
            ref MobileParty party,
            ref bool isTrading,
            ref bool isSpecialActionsPermitted,
            ref CharacterObject initialCharacterOfRightRoster,
            ref InventoryManager.InventoryCategoryType merchantItemType,
            ref IMarketData marketData,
            ref bool useBasePrices,
            ref TextObject leftRosterName)
        {
            try
            {
                if (party.IsPlayerParty()
                    && !isTrading
                    && !Game.Current.CheatMode
                    && BannerlordCheatsSettings.Instance?.NativeItemSpawning == true)
                {
                    var objectTypeList = Game.Current.ObjectManager.GetObjectTypeList<ItemObject>();
                    for (var index = 0; index != objectTypeList.Count; ++index)
                    {
                        var itemObject = objectTypeList[index];
                        leftItemRoster.AddToCounts(itemObject, 10);
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NativeItemSpawning));
            }
        }
    }
}
