using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using ArmyObj = TaleWorlds.CampaignSystem.Army;

namespace BannerlordCheats.Patches.Army
{
    [HarmonyPatch(typeof(ArmyObj), nameof(ArmyObj.DailyCohesionChange), MethodType.Getter)]
    public static class FactionArmyCohesionLossPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CohesionChange(ref ArmyObj instance, ref float result)
        {
            try
            {
                if (!instance.IsOfPlayerKingdom() || instance.IsPlayerArmy() ||
                    !(BannerlordCheatsSettings.Instance?.FactionArmyCohesionLossPercentage < 100f)) return;
                var factor = BannerlordCheatsSettings.Instance.FactionArmyCohesionLossPercentage / 100f;

                result *= factor;
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(FactionArmyCohesionLossPercentage));
            }
        }
    }
}