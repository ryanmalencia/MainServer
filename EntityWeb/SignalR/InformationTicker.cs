using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DataTypes;
using EntityWeb.DBInteraction;

namespace SignalR.InformationTicker
{
    public class InformationTicker
    {
        private readonly static Lazy<InformationTicker> _instance = new Lazy<InformationTicker>(() => new InformationTicker(GlobalHost.ConnectionManager.GetHubContext<InformationTickerHub>().Clients));
        private readonly ConcurrentDictionary<string, Agent> _information = new ConcurrentDictionary<string, Agent>();
        private readonly object _informationLock = new object();
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(1000);
        private volatile bool _updatingInformation = false;

        private InformationTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            AgentDBInteraction interaction = new AgentDBInteraction();
            var information = interaction.GetAllAgents();
            information.Agents.ForEach(info => _information.TryAdd(info.Name, info));

            //_timer = new Timer(UpdateInformation, null, _updateInterval, _updateInterval);
        }

        public static InformationTicker Instance
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
            _information.TryAdd(agent.Name, agent);
            UpdateInformation(null);
        }

        private void BroadcastInformation(Agent info)
        {
            Clients.All.updateInformation(info);
        }
    }
}