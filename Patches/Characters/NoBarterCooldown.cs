using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.BarterSystem;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(BarterManager), nameof(BarterManager.CanPlayerBarterWithHero))]
    public static class NoBarterCooldown
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CanPlayerBarterWithHero(Hero hero, ref bool result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.NoBarterCooldown == true)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoBarterCooldown));
            }
        }
    }
}
