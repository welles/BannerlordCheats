using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using ArmyObj = TaleWorlds.CampaignSystem.Army;

namespace BannerlordCheats.Patches.Army
{
    [HarmonyPatch(typeof(ArmyObj), nameof(ArmyObj.CohesionChange), MethodType.Getter)]
    public static class FactionArmyCohesionLossPercentage
    {
        [HarmonyPostfix]
        public static void CohesionChange(ref ArmyObj __instance, ref float __result)
        {
            if (__instance.IsOfPlayerKingdom()
                && !__instance.IsPlayerArmy()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.FactionArmyCohesionLossPercentage, out var factionArmyCohesionLossPercentage))
            {
                var factor = factionArmyCohesionLossPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
