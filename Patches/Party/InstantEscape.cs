using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(PlayerCaptivityCampaignBehavior), nameof(PlayerCaptivityCampaignBehavior.CheckCaptivityChange))]
    public static class InstantEscape
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CheckCaptivityChange(float dt)
        {
            try
            {
                if (SettingsManager.InstantEscape.IsChanged)
                {
                    PlayerCaptivity.EndCaptivity();
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(InstantEscape));
            }
        }
    }
}
