using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(BarterManager), nameof(BarterManager.CanPlayerBarterWithHero))]
    public static class NoBarterCooldown
    {
        [HarmonyPostfix]
        public static void CanPlayerBarterWithHero(Hero hero, ref bool __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.NoBarterCooldown, out var noBarterCooldown)
                && noBarterCooldown)
            {
                __result = true;
            }
        }
    }
}
