using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultTroopCountLimitModel), nameof(DefaultTroopCountLimitModel.GetHideoutBattlePlayerMaxTroopCount))]
    public static class BanditHideoutTroopLimitPatch
    {
        [HarmonyPostfix]
        public static void GetHideoutBattlePlayerMaxTroopCount(ref int __result)
        {
            __result += BannerlordCheatsSettings.Instance.BanditHideoutTroopLimit;
        }
    }
}
