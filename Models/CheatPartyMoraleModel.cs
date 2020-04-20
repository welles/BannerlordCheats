using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Models
{
    public class CheatPartyMoraleModel : DefaultPartyMoraleModel
    {
        public override float GetEffectivePartyMorale(MobileParty mobileParty, StatExplainer explanation = null)
        {
            if (mobileParty?.IsMainParty ?? false)
            {
                return 100;
            }

            return base.GetEffectivePartyMorale(mobileParty, explanation);
        }
    }
}
