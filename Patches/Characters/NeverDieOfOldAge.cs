using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(KillCharacterAction), nameof(KillCharacterAction.ApplyByOldAge))]
    public static class NeverDieOfOldAge
    {
        [HarmonyPrefix]
        [UsedImplicitly]
        public static bool ApplyByOldAge(
            ref Hero victim,
            ref bool showNotification)
        {
            try
            {
                if (victim.IsPlayer()
                    && SettingsManager.NeverDieOfOldAge.IsChanged)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NeverDieOfOldAge));

                return true;
            }
        }
    }
}
