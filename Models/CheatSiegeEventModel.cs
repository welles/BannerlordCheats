using TaleWorlds.Core;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using System.Linq;

namespace BannerlordCheats.Models
{
    public class CheatSiegeEventModel : DefaultSiegeEventModel
    {
        public override float GetConstructionProgressPerHour(SiegeEngineType type, SiegeEvent siegeEvent, ISiegeEventSide side, StatExplainer explanation = null)
        {
            if (side?.SiegeParties?.Any(x => x.Leader?.IsPlayerCharacter ?? false) ?? false)
            {
                return 1;
            }

            return base.GetConstructionProgressPerHour(type, siegeEvent, side, explanation);
        }
    }
}
