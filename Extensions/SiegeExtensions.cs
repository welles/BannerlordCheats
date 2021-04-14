using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Extensions
{
    public static class SiegeExtensions
    {
        public static bool IsPlayerSiege(this SiegeEvent siege)
        {
            return siege?.IsPlayerSiegeEvent ?? false;
        }
    }
}
