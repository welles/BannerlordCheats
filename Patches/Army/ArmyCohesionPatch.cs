using System.Linq;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using ArmyObj = TaleWorlds.CampaignSystem.Army;

namespace BannerlordCheats.Patches.Army
{
    [HarmonyPatch(typeof(ArmyObj), nameof(ArmyObj.CohesionChange), MethodType.Getter)]
    public static class ArmyCohesionPatch
    {
        [HarmonyPostfix]
        public static void CohesionChange(ref ArmyObj __instance, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.ArmyCohesionLossPercentage, out var armyCohesionLossPercentage)
                && __instance.Parties.Any(x => x.IsPlayerParty()))
            {
                var factor = armyCohesionLossPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
