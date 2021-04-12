using System.Linq;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using ArmyObj = TaleWorlds.CampaignSystem.Army;

namespace BannerlordCheats.Patches.Army
{
    [HarmonyPatch(typeof(ArmyObj), nameof(ArmyObj.CohesionChange), MethodType.Getter)]
    public static class FactionArmyCohesionLossPatch
    {
        [HarmonyPostfix]
        public static void CohesionChange(ref ArmyObj __instance, ref float __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.FactionArmyCohesionLossPercentage, out var factionArmyCohesionLossPercentage)
                && __instance.Kingdom.Clans.Any(x => x.IsPlayerClan())
                && !__instance.Parties.Any(x => x.IsPlayerParty()))
            {
                var factor = factionArmyCohesionLossPercentage / 100f;

                __result *= factor;
            }
        }
    }
}
