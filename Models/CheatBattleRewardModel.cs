using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Models
{
    public class CheatBattleRewardModel : DefaultBattleRewardModel
    {
        public override int CalculateGoldLossAfterDefeat(Hero partyLeaderHero)
        {
            if (partyLeaderHero?.IsHumanPlayerCharacter ?? false)
            {
                return 0;
            }

            return base.CalculateGoldLossAfterDefeat(partyLeaderHero);
        }

        public override float CalculateInfluenceGain(PartyBase party, float influenceValueOfBattle, float contributionShare, StatExplainer explanation = null)
        {
            var modifier = 1f;

            if (party?.Leader?.IsPlayerCharacter ?? false)
            {
                modifier = 2f;
            }

            return modifier * base.CalculateInfluenceGain(party, influenceValueOfBattle, contributionShare, explanation);
        }

        public override float CalculateRenownGain(PartyBase party, float renownValueOfBattle, float contributionShare, StatExplainer explanation = null)
        {
            var modifier = 1f;

            if (party?.Leader?.IsPlayerCharacter ?? false)
            {
                modifier = 2f;
            }

            return modifier * base.CalculateRenownGain(party, renownValueOfBattle, contributionShare, explanation);
        }
    }
}
