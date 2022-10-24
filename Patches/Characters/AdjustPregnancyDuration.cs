using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultPregnancyModel), nameof(DefaultPregnancyModel.PregnancyDurationInDays), MethodType.Getter)]
    public static class AdjustPregnancyDuration
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void PregnancyDurationInDays(ref float result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.AdjustPregnancyDuration < 36)
                {
                    result = BannerlordCheatsSettings.Instance.AdjustPregnancyDuration;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(AdjustPregnancyDuration));
            }
        }
    }
}
