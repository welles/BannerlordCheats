using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Clan
{
    [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetCompanionLimit))]
    public static class ExtraCompanionLimit
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetCompanionLimit(ref TaleWorlds.CampaignSystem.Clan clan, ref int __result)
        {
            try
            {
                if (clan.IsPlayerClan()
                    && SettingsManager.ExtraCompanionLimit.IsChanged)
                {
                    __result += SettingsManager.ExtraCompanionLimit.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ExtraCompanionLimit));
            }
        }
    }
}
