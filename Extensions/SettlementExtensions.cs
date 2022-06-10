using TaleWorlds.CampaignSystem.Settlements;

namespace BannerlordCheats.Extensions
{
    public static class SettlementExtensions
    {
        public static bool IsPlayerTown(this Town town)
        {
            return town?.Owner?.Owner?.IsHumanPlayerCharacter ?? false;
        }

        public static bool IsPlayerVillage(this Village village)
        {
            return village?.Owner?.Owner?.IsHumanPlayerCharacter ?? false;
        }
    }
}
