using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Models
{
    public class CheatClanTierModel : DefaultClanTierModel
    {
        public override int GetCompanionLimitForTier(int clanTier)
        {
            return 100;
        }

        public override int GetPartyLimitForTier(Clan clan, int clanTierToCheck)
        {
            if (clan?.Leader?.IsHumanPlayerCharacter ?? false)
            {
                return 100;
            }

            return base.GetPartyLimitForTier(clan, clanTierToCheck);
        }
    }
}
