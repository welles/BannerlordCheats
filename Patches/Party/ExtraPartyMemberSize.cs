using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

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
                    && BannerlordCheatsSettings.Instance?.ExtraPartyMemberSize > 0)
                {
                    __result.Add(BannerlordCheatsSettings.Instance.ExtraPartyMemberSize);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ExtraPartyMemberSize));
            }
        }
    }
}
