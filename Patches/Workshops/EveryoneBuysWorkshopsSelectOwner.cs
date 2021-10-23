using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

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
            if (BannerlordCheatsSettings.Instance?.EveryoneBuysWorkshops == true
                && excludedHero.IsPlayer())
            {
                requiredGold = 0;
            }
        }
    }
}