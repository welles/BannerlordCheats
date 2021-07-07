using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(EncyclopediaPageVM), "OnTick")]
    public static class EnableHotkeysAddEncyclopediaTroops
    {
        [HarmonyPostfix]
        public static void OnTick(ref EncyclopediaPageVM __instance)
        {
            if (__instance is EncyclopediaUnitPageVM
                && __instance.Obj is CharacterObject characterObject
                && BannerlordCheatsSettings.Instance?.EnableHotkeys == true)
            {
                if (Keys.IsKeyPressed(InputKey.H, InputKey.LeftShift, InputKey.LeftControl))
                {
                    EnableHotkeysAddEncyclopediaTroops.AddTroops(characterObject, 10);
                }
                else if (Keys.IsKeyPressed(InputKey.H, InputKey.LeftControl))
                {
                    EnableHotkeysAddEncyclopediaTroops.AddTroops(characterObject, 1);
                }
            }
        }

        private static void AddTroops(CharacterObject characterObject, int count)
        {
            PartyBase.MainParty.AddMember(characterObject, count);

            var message = string.Format(L10N.GetText("AddTroopsFromEncyclopediaMessage"), count, characterObject.Name);

            InformationManager.DisplayMessage(new InformationMessage(message, Color.White));
        }
    }
}
