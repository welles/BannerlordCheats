using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Experience
{
    [HarmonyPatch(typeof(HeroDeveloper), nameof(HeroDeveloper.GetRequiredFocusPointsToAddFocus))]
    public static class FreeFocusPointAssignment
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRequiredFocusPointsToAddFocus(ref SkillObject skill, ref int __result)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.FreeFocusPointAssignment == true)
                {
                    __result = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(FreeFocusPointAssignment));
            }
        }
    }
}
