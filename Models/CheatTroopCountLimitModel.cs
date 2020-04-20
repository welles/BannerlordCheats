using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Models
{
    public class CheatTroopCountLimitModel : DefaultTroopCountLimitModel
    {
        public override int GetHideoutBattlePlayerMaxTroopCount()
        {
            return 1000;
        }
    }
}
