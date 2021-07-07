using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using ArmyObj = TaleWorlds.CampaignSystem.Army;

namespace BannerlordCheats.Patches.Army
{
    [HarmonyPatch(typeof(ArmyObj), nameof(ArmyObj.CohesionChange), MethodType.Getter)]
    public static class ArmyCohesionLossPercentage
    {
        [HarmonyPostfix]
        public static void CohesionChange(ref ArmyObj __instance, ref float __result)
        {
            if (__instance.IsPlayerArmy()
                && BannerlordCheatsSettings.Instance?.ArmyCohesionLossPercentage < 100f)
            {
                var factor = BannerlordCheatsSettings.Instance.ArmyCohesionLossPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
