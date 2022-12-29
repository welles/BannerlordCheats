using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartyMoraleModel), nameof(DefaultPartyMoraleModel.GetEffectivePartyMorale))]
    public static class ExtraPartyMorale
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetEffectivePartyMorale(ref MobileParty mobileParty, ref bool includeDescription, ref ExplainedNumber __result)
        {
            try
            {
                if (mobileParty.IsPlayerParty()
                    && SettingsManager.ExtraPartyMorale.IsChanged)
                {
                    __result.Add(SettingsManager.ExtraPartyMorale.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ExtraPartyMorale));
            }
        }
    }
}
