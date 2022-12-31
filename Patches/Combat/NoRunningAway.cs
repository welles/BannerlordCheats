﻿using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxBattleMoraleModel), nameof(SandboxBattleMoraleModel.CalculateMoraleChangeToCharacter))]
    public static class NoRunningAway
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateMoraleChangeToCharacter(
            ref Agent agent,
            ref float maxMoraleChange,
            ref float __result)
        {
            try
            {
                if (agent.Origin.TryGetParty(out var party)
                    && party.IsPlayerParty()
                    && SettingsManager.NoRunningAway.IsChanged)
                {
                    __result = 0.0f;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(NoRunningAway));
            }
        }
    }
}
