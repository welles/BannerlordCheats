using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBanditDensityModel), nameof(DefaultBanditDensityModel.GetPlayerMaximumTroopCountForHideoutMission))]
    public static class BanditHideoutTroopLimit
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPlayerMaximumTroopCountForHideoutMission(ref MobileParty party, ref int __result)
        {
            try
            {
                if (SettingsManager.BanditHideoutTroopLimit.IsChanged)
                {
                    __result += SettingsManager.BanditHideoutTroopLimit.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(BanditHideoutTroopLimit));
            }
        }
    }
}
