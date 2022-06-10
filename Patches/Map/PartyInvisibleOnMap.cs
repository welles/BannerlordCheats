using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Map
{
    [HarmonyPatch(typeof(MobileParty), nameof(MobileParty.ShouldBeIgnored), MethodType.Getter)]
    public static class PartyInvisibleOnMap
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void ShouldBeIgnored(ref MobileParty __instance, ref bool __result)
        {
            try
            {
                if (__instance.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.PartyInvisibleOnMap == true)
                {
                    __result = true;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyInvisibleOnMap));
            }
        }
    }
}
