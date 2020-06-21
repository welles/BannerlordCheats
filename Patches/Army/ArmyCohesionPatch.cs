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
                && army.Parties.Any(x => x?.IsMainParty ?? false)
                && BannerlordCheatsSettings.Instance.NoArmyCohesionLoss)
            {
                __result = 0.0f;

                if (explanation != null)
                {
                    explanation.Lines.Clear();
                }
            }
        }
    }
}
