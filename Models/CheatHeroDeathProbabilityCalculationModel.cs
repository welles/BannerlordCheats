using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Models
{
    public class CheatHeroDeathProbabilityCalculationModel : DefaultHeroDeathProbabilityCalculationModel
    {
        public override float CalculateHeroDeathProbability(Hero hero, StatExplainer explanation = null)
        {
            if (hero?.IsHumanPlayerCharacter ?? false)
            {
                return 0;
            }

            return base.CalculateHeroDeathProbability(hero, explanation);
        }
    }
}
