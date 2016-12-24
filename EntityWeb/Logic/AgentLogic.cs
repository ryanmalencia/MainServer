using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class AgentLogic
    {
        public AgentDBInteraction agentDB = new AgentDBInteraction();
        /// <summary>
        /// Get All Agents in DB
        /// </summary>
        /// <returns>Agent Collection with all Agents</returns>
        public AgentCollection GetAllAgents()
        {
            return agentDB.GetAllAgents();
        }
        /// <summary>
        /// Add a new Agent to DB
        /// </summary>
        /// <param name="agent">Agent to Add</param>
        public void Add(Agent agent)
        {
            agentDB.Add(agent);
        }
    }
}