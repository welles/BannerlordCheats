using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Models
{
    public class CheatPartySpeedCalculatingModel : DefaultPartySpeedCalculatingModel
    {
        public override float CalculateFinalSpeed(MobileParty mobileParty, float baseSpeed, StatExplainer explanation)
        {
            float modifier = 1;

            if (mobileParty?.IsMainParty ?? false)
            {
                modifier = 4;
            }

            var originalSpeed = base.CalculateFinalSpeed(mobileParty, baseSpeed, explanation);

            return modifier * originalSpeed;
        }
    }
}
