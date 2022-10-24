﻿using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using StoryMode.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    [HarmonyPatch(typeof(SandboxAgentDecideKilledOrUnconsciousModel), nameof(SandboxAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    [HarmonyPatch(typeof(StoryModeAgentDecideKilledOrUnconsciousModel), nameof(StoryModeAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyLordCombatDeathPercentageBattle
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float result)
        {
            try
            {
                if (!effectedAgent.IsHero()
                    || !effectedAgent.IsPlayerEnemy()
                    || !(BannerlordCheatsSettings.Instance?.EnemyLordCombatDeathPercentage < 100f)) return;
                var factor = BannerlordCheatsSettings.Instance.EnemyLordCombatDeathPercentage / 100f;

                result *= factor;
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnemyLordCombatDeathPercentageBattle));
            }
        }
    }
}
