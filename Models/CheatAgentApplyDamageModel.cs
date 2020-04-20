using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using SandBox;

namespace BannerlordCheats.Models
{
    public class CheatAgentApplyDamageModel : SandboxAgentApplyDamageModel
    {
        public override int CalculateDamage(BasicCharacterObject affectorBasicCharacter, BasicCharacterObject affectedBasicCharacter, MissionWeapon offHandItem, bool isHeadShot, bool isAffectedAgentMount, bool isAffectedAgentHuman, bool hasAffectorAgentMount, bool isAffectedAgentNull, bool isAffectorAgentHuman, AttackCollisionData collisionData, WeaponComponentData weapon)
        {
            if (affectedBasicCharacter?.IsPlayerCharacter ?? false)
            {
                return 0;
            }

            //else if (affectorBasicCharacter?.IsPlayerCharacter ?? false)
            //{
            //    return affectedBasicCharacter?.HitPoints ?? 1000;
            //}

            return base.CalculateDamage(affectorBasicCharacter, affectedBasicCharacter, offHandItem, isHeadShot, isAffectedAgentMount, isAffectedAgentHuman, hasAffectorAgentMount, isAffectedAgentNull, isAffectorAgentHuman, collisionData, weapon);
        }
    }
}
