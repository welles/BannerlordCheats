using System.Linq;
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
            if (BannerlordCheatsSettings.Instance.ArmyCohesionLossPercentage < 100
                && __instance.Parties.Any(x => x.IsMainParty))
            {
                var factor = BannerlordCheatsSettings.Instance.ArmyCohesionLossPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
