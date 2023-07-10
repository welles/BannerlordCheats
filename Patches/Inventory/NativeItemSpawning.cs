using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Inventory;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace BannerlordCheats.Patches.Inventory
{
    [HarmonyPatch(typeof(InventoryLogic), nameof(InventoryLogic.Initialize),
        typeof(ItemRoster),
        typeof(MobileParty),
        typeof(bool),
        typeof(bool),
        typeof(CharacterObject),
        typeof(InventoryManager.InventoryCategoryType),
        typeof(IMarketData),
        typeof(bool),
        typeof(TextObject),
        typeof(TroopRoster),
        typeof(InventoryLogic.CapacityData))]
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
            ref TextObject leftRosterName,
            ref TroopRoster leftMemberRoster,
            ref InventoryLogic.CapacityData otherSideCapacityData)
        {
            try
            {
                if (party.IsPlayerParty()
                    && !isTrading
                    && !Game.Current.CheatMode
                    && SettingsManager.NativeItemSpawning.IsChanged)
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
