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
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyPrisonerSizeLimit))]
    public static class ExtraPartyPrisonerSize
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPartyPrisonerSizeLimit(ref PartyBase party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.ExtraPartyPrisonerSize.IsChanged)
                {
                    __result.Add(SettingsManager.ExtraPartyPrisonerSize.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ExtraPartyPrisonerSize));
            }
        }
    }
}
