using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Models
{
    public class CheatCharacterDevelopmentModel : DefaultCharacterDevelopmentModel
    {
        public override float CalculateLearningRate(Hero hero, SkillObject skill, StatExplainer explainer = null)
        {
            if (hero?.IsHumanPlayerCharacter ?? false)
            {
                return 1000;
            }

            return base.CalculateLearningRate(hero, skill, explainer);
        }
    }
}
