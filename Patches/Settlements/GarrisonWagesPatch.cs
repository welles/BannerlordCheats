using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(MobileParty), nameof(MobileParty.GetTotalWage))]
    public static class GarrisonWagesPatch
    {
        [HarmonyPostfix]
        public static void GetTotalWage(float constant, StatExplainer description, ref MobileParty __instance, ref int __result)
        {
            if (__instance.IsGarrison
                && (__instance.Party?.Owner?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.GarrisonWagesPercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.GarrisonWagesPercentage / 100f;

                var newValue = (int)Math.Round(__result * factor);

                __result = newValue;

                description?.Lines.ForEach(x => x.Number *= factor);
            }
        }
    }
}
