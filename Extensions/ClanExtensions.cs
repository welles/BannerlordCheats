using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Extensions
{
    public static class ClanExtensions
    {
        public static bool IsPlayerClan(this Clan clan)
        {
            return clan?.Leader?.IsHumanPlayerCharacter ?? false;
        }

        public static bool IsPlayerClan(this PartyBase party)
        {
            return party?.Owner?.Clan?.IsPlayerClan() ?? false;
        }
    }
}
