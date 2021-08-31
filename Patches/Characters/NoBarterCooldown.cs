using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(BarterManager), nameof(BarterManager.CanPlayerBarterWithHero))]
    public static class NoBarterCooldown
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CanPlayerBarterWithHero(Hero hero, ref bool __result)
        {
            if (BannerlordCheatsSettings.Instance?.NoBarterCooldown == true)
            {
                __result = true;
            }
        }
    }
}
