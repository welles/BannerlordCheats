using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Extensions
{
    public static class AgentExtensions
    {
        /// <summary>
        /// Tries to extract a human character regardless of whether the the agent being evaluated is riding a horse or not
        /// </summary>
        /// <param name="agent">The agent to evaluate</param>
        /// <param name="character">The human character or null</param>
        /// <returns>Returns true if a human character was found</returns>
        public static bool TryGetHuman(this Agent agent, out Agent character)
        {
            if (agent == null)
            {
                character = null;
                return false;
            }
            if (agent.IsHuman)
            {
                character = agent;
                return true;
            }
            if (agent.IsMount)
            {
                character = agent.RiderAgent;
                return character != null;
            }
            character = null;
            return false;
        }
    }
}
