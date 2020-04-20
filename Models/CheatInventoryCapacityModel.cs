using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Models
{
    public class CheatInventoryCapacityModel : DefaultInventoryCapacityModel
    {
        public override int CalculateInventoryCapacity(MobileParty mobileParty, StatExplainer explanation = null, int additionalTroops = 0, int additionalSpareMounts = 0, int additionalPackAnimals = 0, bool includeFollowers = false)
        {
            if (mobileParty?.IsMainParty ?? false)
            {
                return 100000;
            }

            return base.CalculateInventoryCapacity(mobileParty, explanation, additionalTroops, additionalSpareMounts, additionalPackAnimals, includeFollowers);
        }
    }
}
