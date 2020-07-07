using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTotalWage))]
    public static class NoTroopWagesPatch
    {
        [HarmonyPostfix]
        public static void GetTotalWage(MobileParty mobileParty, StatExplainer explanation, ref int __result)
        {
            if ((mobileParty?.IsMainParty ?? false)
                && BannerlordCheatsSettings.Instance.TroopWagesPercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.TroopWagesPercentage / 100f;

                var newValue = (int)Math.Round(__result * factor);

                __result = newValue;

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
