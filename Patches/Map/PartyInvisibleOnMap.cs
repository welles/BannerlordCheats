using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Map
{
    [HarmonyPatch(typeof(MobileParty), nameof(MobileParty.ShouldBeIgnored), MethodType.Getter)]
    public static class PartyInvisibleOnMap
    {
        [HarmonyPostfix]
        public static void ShouldBeIgnored(ref MobileParty __instance, ref bool __result)
        {
            if (__instance.IsPlayerParty()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.PartyInvisibleOnMap, out var partyInvisibleOnMap)
                && partyInvisibleOnMap)
            {
                __result = true;
            }
        }
    }
}
