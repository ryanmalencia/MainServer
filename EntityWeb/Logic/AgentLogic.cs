using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class AgentLogic
    {
        public AgentDBInteraction AgentDB = new AgentDBInteraction();
        /// <summary>
        /// Get All Agents in DB
        /// </summary>
        /// <returns>Agent Collection with all Agents</returns>
        public AgentCollection GetAllAgents()
        {
            return AgentDB.GetAllAgents();
        }
        /// <summary>
        /// Add a new Agent to DB
        /// </summary>
        /// <param name="agent">Agent to Add</param>
        public void Add(Agent agent)
        {
            AgentDB.Add(agent);
        }
        /// <summary>
        /// Get All Idle Agents
        /// </summary>
        /// <returns>AgentCollection contaning idle Agents</returns>
        public AgentCollection GetIdleAgents()
        {
            return AgentDB.GetIdleMachines();
        }
        /// <summary>
        /// Get Agent Based On HostName
        /// </summary>
        /// <param name="AgentName">String of Desired Agent HostName</param>
        /// <returns></returns>
        public Agent Get(string AgentName)
        {
            return AgentDB.Get(AgentName);
        }
        /// <summary>
        /// Set Specified Agent to Running State
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Set</param>
        /// <param name="pk_job">Job pk to Give to Agent</param>
        public void SetAgentRunning(string AgentName, int pk_job)
        {
            AgentDB.SetAgentRunning(AgentName, pk_job);
        }
        /// <summary>
        /// Set Specified Agent to Queued State
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Set</param>
        public void SetAgentQueued(string AgentName)
        {
            AgentDB.SetAgentQueued(AgentName);
        }
        /// <summary>
        /// Set Specified Agent to Idle State
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Set</param>
        public void SetAgentIdle(string AgentName)
        {
            AgentDB.SetAgentIdle(AgentName);
        }
        /// <summary>
        /// Set Specified Agent to Dead State
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Set</param>
        public void SetAgentDead(string AgentName)
        {
            AgentDB.SetAgentDead(AgentName);
        }
        /// <summary>
        /// Delete the Specified Agent
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Delete</param>
        public void Delete(string AgentName)
        {
            AgentDB.Delete(AgentName);
        }
    }
}