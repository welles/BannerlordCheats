using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPlayerCaptivityModel), nameof(DefaultPlayerCaptivityModel.CheckCaptivityChange))]
    public static class InstantEscape
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CheckCaptivityChange(float dt, ref string result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.InstantEscape == true)
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
