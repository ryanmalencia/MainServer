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
        public bool Add(Agent agent)
        {
            bool status = AgentDB.Add(agent);
            //Here we trigger SignalR to show that a new agent has been added
            AgentTicker.AddAgent(agent);
            return status;
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
        public string SetAgentRunning(string AgentName, int pk_job)
        {
            string jobname = AgentDB.SetAgentRunning(AgentName, pk_job);
            AgentTicker.SetAgentRunning(AgentName,jobname);
            return jobname;
        }
        /// <summary>
        /// Set Specified Agent to Queued State
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Set</param>
        public Agent SetAgentQueued(string AgentName)
        {
            return AgentDB.SetAgentQueued(AgentName);
        }
        /// <summary>
        /// Set Specified Agent to Idle State
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Set</param>
        public Agent SetAgentIdle(string AgentName)
        {
            Agent agent = AgentDB.SetAgentIdle(AgentName);
            AgentTicker.SetAgentIdle(AgentName);
            return agent;
        }
        /// <summary>
        /// Set Specified Agent to Dead State
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Set</param>
        public Agent SetAgentDead(string AgentName)
        {
            Agent agent = AgentDB.SetAgentDead(AgentName);
            AgentTicker.SetAgentDead(AgentName);
            return agent;
        }
        /// <summary>
        /// Delete the Specified Agent
        /// </summary>
        /// <param name="AgentName">Agent Hostname to Delete</param>
        public bool Delete(string AgentName)
        {
            bool status = AgentDB.Delete(AgentName);
            if (status)
            {
                AgentTicker.DeleteAgent(AgentName);
            }
            return status;
        }
        /// <summary>
        /// Update an Agent
        /// </summary>
        /// <param name="Agent">Agent to Update</param>
        public Agent Update(Agent Agent)
        {
            return AgentDB.Update(Agent);
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