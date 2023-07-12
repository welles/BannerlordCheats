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
        public static void PregnancyDurationInDays(ref float __result)
        {
            try
            {
                if (SettingsManager.AdjustPregnancyDuration.IsChanged)
                {
                    __result = SettingsManager.AdjustPregnancyDuration.Value;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(AdjustPregnancyDuration));
            }
        }
    }
}
