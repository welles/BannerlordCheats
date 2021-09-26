using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Map
{
    [HarmonyPatch(typeof(MobileParty), nameof(MobileParty.ShouldBeIgnored), MethodType.Getter)]
    public static class PartyInvisibleOnMap
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void ShouldBeIgnored(ref MobileParty __instance, ref bool __result)
        {
            if (__instance.IsPlayerParty()
                && BannerlordCheatsSettings.Instance?.PartyInvisibleOnMap == true)
            {
                __result = true;
            }
        }
    }
}
