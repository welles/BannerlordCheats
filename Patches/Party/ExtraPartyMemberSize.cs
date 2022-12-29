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
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyMemberSizeLimit))]
    public static class ExtraPartyMemberSize
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPartyMemberSizeLimit(ref PartyBase party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.ExtraPartyMemberSize.IsChanged)
                {
                    __result.Add(SettingsManager.ExtraPartyMemberSize.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ExtraPartyMemberSize));
            }
        }
    }
}
