using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Extensions
{
    public static class ClanExtensions
    {
        public static bool IsPlayerClan(this Clan clan)
        {
            return clan?.Leader?.IsHumanPlayerCharacter ?? false;
        }
    }
}
