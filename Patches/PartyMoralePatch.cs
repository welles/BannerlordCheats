using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartyMoraleModel), "GetEffectivePartyMorale")]
    public static class PartyMoralePatch
    {
        [HarmonyPostfix]
        public static void GetEffectivePartyMorale(MobileParty mobileParty, StatExplainer explanation, ref float __result)
        {
            if (mobileParty?.IsMainParty ?? false)
            {
                __result += BannerlordCheatsSettings.Instance.ExtraPartyMorale;
            }
        }
    }
}
