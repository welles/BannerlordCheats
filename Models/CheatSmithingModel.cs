using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordCheats.Models
{
    public class CheatSmithingModel : DefaultSmithingModel
    {
        public override int GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero)
        {
            if (hero?.IsHumanPlayerCharacter ?? false)
            {
                return 0;
            }

            return base.GetEnergyCostForRefining(ref refineFormula, hero);
        }

        public override int GetEnergyCostForSmelting(ItemObject item, Hero hero)
        {
            if (hero?.IsHumanPlayerCharacter ?? false)
            {
                return 0;
            }

            return base.GetEnergyCostForSmelting(item, hero);
        }

        public override int GetEnergyCostForSmithing(ItemObject item, Hero hero)
        {
            if (hero?.IsHumanPlayerCharacter ?? false)
            {
                return 0;
            }

            return base.GetEnergyCostForSmithing(item, hero);
        }

        public override int GetModifierTierForSmithedWeapon(WeaponDesign weaponDesign, Hero hero)
        {
            return base.GetModifierTierForSmithedWeapon(weaponDesign, hero);
        }

        public override int GetPartResearchGainForSmeltingItem(ItemObject item, Hero hero)
        {
            return base.GetPartResearchGainForSmeltingItem(item, hero);
        }

        public override int GetPartResearchGainForSmithingItem(ItemObject item, Hero hero)
        {
            return base.GetPartResearchGainForSmithingItem(item, hero);
        }
    }
}
