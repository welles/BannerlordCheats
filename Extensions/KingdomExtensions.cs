using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Extensions
{
    public static class KingdomExtensions
    {
        public static bool IsPlayerKingdom(this Clan clan)
        {
            return clan?.Kingdom?.IsPlayerKingdom() ?? false;
        }

        public static bool IsPlayerKingdom(this Kingdom kingdom)
        {
            return kingdom?.Clans?.Any(x => x.IsPlayerClan()) ?? false;
        }

        public static bool IsPlayerKingdom(this PartyBase party)
        {
            return party?.Owner?.Clan?.IsPlayerKingdom() ?? false;
        }
    }
}
