using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Mission), nameof(Mission.HandleMissileCollisionReaction))]
    public static class NoStuckArrows
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static void HandleMissileCollisionReaction(
            ref int missileIndex,
            ref Mission.MissileCollisionReaction collisionReaction,
            ref MatrixFrame attachLocalFrame,
            ref Agent attackerAgent,
            ref Agent attachedAgent,
            ref bool attachedToShield,
            ref sbyte attachedBoneIndex,
            ref MissionObject attachedMissionObject,
            ref Vec3 bounceBackVelocity,
            ref Vec3 bounceBackAngularVelocity,
            ref int forcedSpawnIndex)
        {
            if (attachedAgent.IsPlayer()
                && collisionReaction == Mission.MissileCollisionReaction.Stick
                && BannerlordCheatsSettings.Instance?.NoStuckArrows == true)
            {
                collisionReaction = Mission.MissileCollisionReaction.BecomeInvisible;
            }
        }
    }
}
