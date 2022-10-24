using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;
using TaleWorlds.InputSystem;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(EncyclopediaPageVM), "OnTick")]
    public static class EnableHotkeysAddEncyclopediaTroops
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(ref EncyclopediaPageVM instance)
        {
            try
            {
                if (!(instance is EncyclopediaUnitPageVM)
                    || !(instance.Obj is CharacterObject characterObject)
                    || BannerlordCheatsSettings.Instance?.EnableHotkeys != true) return;
                if (Keys.IsKeyPressed(InputKey.H, InputKey.LeftShift, InputKey.LeftControl))
                {
                    AddTroops(characterObject, 10);
                }
                else if (Keys.IsKeyPressed(InputKey.H, InputKey.LeftControl))
                {
                    AddTroops(characterObject, 1);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnableHotkeysAddEncyclopediaTroops));
            }
        }

        private static void AddTroops(CharacterObject characterObject, int count)
        {
            PartyBase.MainParty.AddMember(characterObject, count);

            var message = string.Format(L10N.GetText("AddTroopsFromEncyclopediaMessage"), count, characterObject.Name);

            Message.Show(message);
        }
    }
}
