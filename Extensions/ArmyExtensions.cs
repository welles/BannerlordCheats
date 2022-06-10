using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Extensions
{
    public static class ArmyExtensions
    {
        public static bool IsPlayerArmy(this Army army)
        {
            return army?.Parties?.Any(x => x.IsPlayerParty()) ?? false;
        }

        public static bool IsPlayerArmy(this MobileParty party)
        {
            return party?.Army?.IsPlayerArmy() ?? false;
        }

        public static bool IsOfPlayerKingdom(this Army army)
        {
            return army?.Kingdom?.IsPlayerKingdom() ?? false;
        }
    }
}
