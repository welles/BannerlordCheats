using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Extensions
{
    public static class PartyExtensions
    {
        public static bool IsPlayerParty(this PartyBase party)
        {
            // Workaround for crash on accessing BanditPartyComponent.Owner
            if (party?.MapFaction?.IsBanditFaction == true)
            {
                return false;
            }

            return party?.Owner?.IsHumanPlayerCharacter ?? false;
        }

        public static bool IsPlayerParty(this MobileParty party)
        {
            return party?.Party?.IsPlayerParty() ?? false;
        }
    }
}
