using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Localization;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(ChangeOwnerOfWorkshopAction), nameof(ChangeOwnerOfWorkshopAction.ApplyByTrade))]
    public static class EveryoneBuysWorkshopsCost
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static void ApplyByTrade(
            ref Workshop workshop,
            ref Hero newOwner,
            ref WorkshopType workshopType,
            ref int capital,
            ref bool upgradable,
            ref int cost,
            ref TextObject customName)
        {
            if (BannerlordCheatsSettings.Instance?.EveryoneBuysWorkshops == true
                && workshop.Owner.IsPlayer()
                && cost > newOwner.Gold)
            {
                newOwner.Gold = cost;
            }
        }
    }
}