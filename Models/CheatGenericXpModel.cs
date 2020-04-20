using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Models
{
    public class CheatGenericXpModel : DefaultGenericXpModel
    {
        public override float GetXpMultiplier(Hero hero)
        {
            float modifier = 1;

            if (hero?.IsHumanPlayerCharacter ?? false)
            {
                modifier = 10000;
            }

            var baseXpMultiplier = base.GetXpMultiplier(hero);

            return baseXpMultiplier * modifier;
        }
    }
}
