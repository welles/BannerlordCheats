using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultPregnancyModel), nameof(DefaultPregnancyModel.PregnancyDurationInDays), MethodType.Getter)]
    public static class AdjustPregnancyDuration
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void PregnancyDurationInDays(ref float __result)
        {
            if (BannerlordCheatsSettings.Instance?.AdjustPregnancyDuration < 36)
            {
                __result = BannerlordCheatsSettings.Instance.AdjustPregnancyDuration;
            }
        }
    }
}