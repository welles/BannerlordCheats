using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
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

        /// <summary>
        /// Tries to get the PartyBase of the Agent origin being evaluated
        /// </summary>
        /// <param name="origin">The Agent origin to evaluate</param>
        /// <param name="party">The Agent's party or null</param>
        /// <returns>Returns true if the Agent's party was found</returns>
        public static bool TryGetParty(this IAgentOriginBase origin, out PartyBase party)
        {
            switch (origin)
            {
                case PartyAgentOrigin partyAgentOrigin:
                    party = partyAgentOrigin.Party;
                    return party != null;
                case PartyGroupAgentOrigin partyGroupAgentOrigin:
                    party = partyGroupAgentOrigin.Party;
                    return party != null;
                case SimpleAgentOrigin simpleAgentOrigin:
                    party = simpleAgentOrigin.Party;
                    return party != null;
                default:
                    party = null;
                    return false;
            }
        }

        public static bool IsPlayer(this Agent agent)
        {
            return agent?.Character?.IsPlayer() ?? false;
        }
    }
}
