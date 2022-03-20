using System;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Extensions
{
    public static class PartyExtensions
    {
        public static bool IsPlayerParty(this PartyBase party)
        {
            // Workaround for crash on accessing BanditPartyComponent.Owner
            Hero owner;
            try
            {
                owner = party?.Owner;
            }
            catch (NullReferenceException)
            {
                return false;
            }

            return owner?.IsHumanPlayerCharacter ?? false;
        }

        public static bool IsPlayerParty(this MobileParty party)
        {
            return party?.Party?.IsPlayerParty() ?? false;
        }
    }
}
