using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Models
{
    public class CheatMapVisibilityModel : DefaultMapVisibilityModel
    {
        public override float GetPartySpottingRange(MobileParty party, StatExplainer explainer)
        {
            float modifier = 1;

            if (party?.IsMainParty ?? false)
            {
                modifier = 10;
            }

            var originalValue = base.GetPartySpottingRange(party, explainer);

            return modifier * originalValue;
        }
    }
}
