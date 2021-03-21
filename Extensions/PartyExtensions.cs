using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Extensions
{
    public static class PartyExtensions
    {
        public static bool IsPlayerParty(this PartyBase party)
        {
            return party?.Owner?.IsHumanPlayerCharacter ?? false;
        }
    }
}
