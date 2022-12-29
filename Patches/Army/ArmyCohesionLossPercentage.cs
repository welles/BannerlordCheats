using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using ArmyObj = TaleWorlds.CampaignSystem.Army;

namespace BannerlordCheats.Patches.Army
{
    [HarmonyPatch(typeof(ArmyObj), nameof(ArmyObj.DailyCohesionChange), MethodType.Getter)]
    public static class ArmyCohesionLossPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CohesionChange(ref ArmyObj __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerArmy()
                    && SettingsManager.ArmyCohesionLossPercentage.IsChanged)
                {
                    var factor = SettingsManager.ArmyCohesionLossPercentage.Value / 100f;

                    __result *= factor;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ArmyCohesionLossPercentage));
            }
        }
    }
}
