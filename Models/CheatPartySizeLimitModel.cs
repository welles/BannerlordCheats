using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Models
{
    class CheatPartySizeLimitModel : DefaultPartySizeLimitModel
    {
        public override int GetPartyMemberSizeLimit(PartyBase party, StatExplainer explanation = null)
        {
            if (party?.Leader?.IsPlayerCharacter ?? false)
            {
                return 1000;
            }

            return base.GetPartyMemberSizeLimit(party, explanation);
        }

        public override int GetPartyPrisonerSizeLimit(PartyBase party, StatExplainer explanation = null)
        {
            if (party?.Leader?.IsPlayerCharacter ?? false)
            {
                return 1000;
            }

            return base.GetPartyPrisonerSizeLimit(party, explanation);
        }
    }
}
