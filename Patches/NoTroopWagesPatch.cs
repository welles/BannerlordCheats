using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), "GetTotalWage")]
    public static class NoTroopWagesPatch
    {
        [HarmonyPostfix]
        public static void GetTotalWage(MobileParty mobileParty, StatExplainer explanation, ref int __result)
        {
            if ((mobileParty?.IsMainParty ?? false)
                && BannerlordCheatsSettings.Instance.NoTroopWages)
            {
                __result = 0;
            }
        }
    }
}
