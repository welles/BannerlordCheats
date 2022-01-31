using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Characters
{
    [HarmonyPatch(typeof(DefaultPersuasionModel), nameof(DefaultPersuasionModel.GetChances))]
    public static class ConversationAlwaysSuccessful
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetChances(PersuasionOptionArgs optionArgs, ref float successChance, ref float critSuccessChance, ref float critFailChance, ref float failChance, float difficultyMultiplier)
        {
            try
            {
                if (BannerlordCheatsSettings.Instance?.ConversationAlwaysSuccessful == true)
                {
                    successChance = 1;
                    critSuccessChance = 1;
                    failChance = 0;
                    critFailChance = 0;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ConversationAlwaysSuccessful));
            }
        }
    }
}
