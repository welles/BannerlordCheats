using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(HeroDeveloper), nameof(HeroDeveloper.GetRequiredFocusPointsToAddFocus))]
    public static class FreeFocusAssignmentPatch
    {
        [HarmonyPostfix]
        public static void GetRequiredFocusPointsToAddFocus(ref SkillObject skill, ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.FreeFocusPointAssignment, out var freeFocusPointAssignment)
                && freeFocusPointAssignment)
            {
                __result = 0;
            }
        }
    }
}
