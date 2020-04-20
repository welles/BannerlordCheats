using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Models
{
    public class CheatBuildingConstructionModel : DefaultBuildingConstructionModel
    {
        public override int CalculateDailyConstructionPower(Town town, StatExplainer explanation = null)
        {
            var modifier = 1;

            if (town?.Owner?.Leader?.IsPlayerCharacter ?? false)
            {
                modifier = 100;
            }

            var originalValue = base.CalculateDailyConstructionPower(town, explanation);

            return modifier * originalValue;
        }

        public override int CalculateDailyConstructionPowerWithoutBoost(Town town, StatExplainer explanation = null)
        {
            var modifier = 1;

            if (town?.Owner?.Leader?.IsPlayerCharacter ?? false)
            {
                modifier = 100;
            }

            var originalValue = base.CalculateDailyConstructionPowerWithoutBoost(town, explanation);

            return modifier * originalValue;
        }
    }
}
