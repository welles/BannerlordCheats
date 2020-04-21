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
    }
}
