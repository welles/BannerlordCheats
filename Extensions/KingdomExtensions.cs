using System.Linq;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Extensions
{
    public static class KingdomExtensions
    {
        public static bool IsPlayerKingdom(this Kingdom kingdom)
        {
            return kingdom?.Clans?.Any(x => x.IsPlayerClan()) ?? false;
        }
    }
}
