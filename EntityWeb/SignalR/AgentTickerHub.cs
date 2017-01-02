using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DataTypes;

namespace SignalR.AgentTicker
{
    [HubName("InformationHub")]
    public class AgentTickerHub : Hub
    {
        private readonly AgentTicker _agentTicker;

        public AgentTickerHub() : this(AgentTicker.Instance) { }

        public AgentTickerHub(AgentTicker agentTicker)
        {
            _agentTicker = agentTicker;
        }

        public IEnumerable<Agent> getAllInformation()
        {
            return _agentTicker.GetAllInformation();
        }
    }
}