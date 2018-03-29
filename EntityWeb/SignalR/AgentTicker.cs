using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DataTypes;
using EntityWeb.DBInteraction;

namespace SignalR.AgentTicker
{
    public class AgentTicker
    {
        private readonly static Lazy<AgentTicker> _instance = new Lazy<AgentTicker>(() => new AgentTicker(GlobalHost.ConnectionManager.GetHubContext<AgentTickerHub>().Clients));
        private readonly ConcurrentDictionary<string, Agent> _information = new ConcurrentDictionary<string, Agent>();
        private readonly object _informationLock = new object();
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(1000);
        private volatile bool _updatingInformation = false;

        private AgentTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            AgentDBInteraction interaction = new AgentDBInteraction();
            var information = interaction.GetAllAgents();
            information.Agents.ForEach(info => _information.TryAdd(info.Name, info));

            //_timer = new Timer(UpdateInformation, null, _updateInterval, _updateInterval);
        }

        public static AgentTicker Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public IEnumerable<Agent> GetAllInformation()
        {
            return _information.Values;
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        private void UpdateInformation(object state)
        {
            lock(_informationLock)
            {
                if(!_updatingInformation)
                {
                    _updatingInformation = true;
                    foreach(var info in _information.Values)
                    {
                        BroadcastInformation(info);
                    }
                    _updatingInformation = false;
                }
            }
        }

        public void AddAgent(Agent agent)
        {
            Clients.All.addMachine(agent);
            Clients.All.addAgent(agent.Name);
        }

        public void DeleteAgent(string AgentName)
        {
            Clients.All.deleteAgent(AgentName);
        }

        public void SetAgentRunning(string AgentName,string JobName)
        {
            Clients.All.updateRunning(AgentName,JobName);
        }

        public void SetAgentIdle(string AgentName)
        {
            Clients.All.updateIdle(AgentName);
        }

        public void SetAgentDead(string AgentName)
        {
            Clients.All.updateDead(AgentName);
        }

        private void BroadcastInformation(Agent info)
        {
            Clients.All.updateInformation(info);
        }
    }
}