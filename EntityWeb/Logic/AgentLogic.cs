using EntityWeb.DBInteraction;
using DataTypes;
using SignalR.AgentTicker;
using SignalR.AgentStatus;
using System;
using System.Net;
using System.Threading;
using WebAPIClient.APICalls;
using Newtonsoft.Json;


namespace EntityWeb.Logic
{
    public class AgentLogic
    {
        private AgentDBInteraction AgentDB = new AgentDBInteraction();
        private AgentTicker AgentTicker = AgentTicker.Instance;
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
            //Here we trigger SignalR to show that a new agent has been added
            AgentTicker.AddAgent(agent);
        }
        /// <summary>
        /// Get All Idle Agents
        /// </summary>
        /// <returns>AgentCollection contaning idle Agents</returns>
        public AgentCollection GetIdleAgents()
        {
            return AgentDB.GetIdleAgents();
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
            string jobname = AgentDB.SetAgentRunning(AgentName, pk_job);
            AgentTicker.SetAgentRunning(AgentName,jobname);
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
            AgentTicker.SetAgentIdle(AgentName);
        }
        /// <summary>
        /// Set Specified Agent to Dead State
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Set</param>
        public void SetAgentDead(string AgentName)
        {
            AgentDB.SetAgentDead(AgentName);
            AgentTicker.SetAgentDead(AgentName);
        }
        /// <summary>
        /// Delete the Specified Agent
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Delete</param>
        public void Delete(string AgentName)
        {
            AgentDB.Delete(AgentName);
        }
        /// <summary>
        /// Update an Agent
        /// </summary>
        /// <param name="Agent">Agent to Update</param>
        public void Update(Agent Agent)
        {
            AgentDB.Update(Agent);
        }

        public void Kill(string agent)
        {
            Agent current = AgentAPI.GetAgent(agent);
            if (current != null)
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("content-type", "application/json");
                        client.UploadString("http://" + current.IP + "/api/machine/kill/", "POST", "");
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        public void Shutdown(string agent)
        {
            Agent current = AgentAPI.GetAgent(agent);
            if (current != null)
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("content-type", "application/json");
                        client.UploadString("http://" + current.IP + "/api/machine/shutdown/", "POST", "");
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        public void UpdateHardware(Hardware info)
        {
            AgentStatus.Instance.UpdateHardware(info);
        }

        public void UpdateJob(string info)
        {
            AgentStatus.Instance.UpdateJob(info);
        }
    }
}