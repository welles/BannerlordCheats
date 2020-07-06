using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultArmyManagementCalculationModel), nameof(DefaultArmyManagementCalculationModel.CalculateCohesionChange))]
    public static class ArmyCohesionPatch
    {
        [HarmonyPostfix]
        public static void CalculateCohesionChange(Army army, StatExplainer explanation, ref float __result)
        {
            if (army != null
                && army.Parties.Any(x => x?.IsMainParty ?? false))
            {
                var factor = BannerlordCheatsSettings.Instance.ArmyCohesionLossPercentage / 100f;

                __result *= factor;

                if (explanation != null)
                {
                    foreach (var line in explanation.Lines)
                    {
                        line.Number *= factor;
                    }
                }
            }
        }
    }
}
