using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Extensions
{
    public static class PartyExtensions
    {
        public static bool IsPlayerParty(this PartyBase party)
        {
            return party?.Owner?.IsHumanPlayerCharacter ?? false;
        }

        public static bool IsPlayerParty(this MobileParty party)
        {
            return party?.Party?.IsPlayerParty() ?? false;
        }
    }
}
