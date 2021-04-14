using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Extensions
{
    public static class HeroExtensions
    {
        public static bool IsPlayer(this Hero hero)
        {
            return hero?.IsHumanPlayerCharacter ?? false;
        }

        public static bool IsPlayerCompanion(this Hero hero)
        {
            return hero?.IsPlayerCompanion ?? false;
        }
    }
}
