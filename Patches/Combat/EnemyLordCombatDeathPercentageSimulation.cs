namespace BannerlordCheats.Patches.Combat
{
    /*
    [HarmonyPatch(typeof(DefaultCombatSimulationModel), nameof(DefaultCombatSimulationModel.SimulateHit))]
    public static class EnemyLordCombatDeathPercentageSimulation
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void SimulateHit(ref CharacterObject strikerTroop, ref CharacterObject struckTroop, ref PartyBase strikerParty, ref PartyBase struckParty, ref float strikerAdvantage, ref MapEvent battle, ref int __result)
        {
            if (struckTroop.IsHero()
                && !struckParty.IsPlayerKingdom()
                && SettingsManager.EnemyLordCombatDeathPercentage.IsChanged)
            {
                var factor = SettingsManager.EnemyLordCombatDeathPercentage.Value / 100f;

                __result = (int) Math.Round(__result / factor);
            }
        }
    }
    */
}
