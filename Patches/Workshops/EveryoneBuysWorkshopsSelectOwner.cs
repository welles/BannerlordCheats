using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Workshops;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.SelectNextOwnerForWorkshop))]
    public static class EveryoneBuysWorkshopsSelectOwner
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static void SelectNextOwnerForWorkshop(
            ref Town town,
            ref Workshop workshop,
            ref Hero excludedHero,
            ref int requiredGold)
        {
            try
            {
                if (SettingsManager.EveryoneBuysWorkshops.IsChanged
                    && excludedHero.IsPlayer())
                {
                    requiredGold = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EveryoneBuysWorkshopsSelectOwner));
            }
        }
    }
}
