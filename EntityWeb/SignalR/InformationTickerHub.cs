using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DataTypes;

namespace SignalR.InformationTicker
{
    [HubName("InformationHub")]
    public class InformationTickerHub : Hub
    {
        private readonly InformationTicker _informationTicker;

        public InformationTickerHub() : this(InformationTicker.Instance) { }

        public InformationTickerHub(InformationTicker infoTicker)
        {
            _informationTicker = infoTicker;
        }

        public IEnumerable<Agent> getAllInformation()
        {
            return _informationTicker.GetAllInformation();
        }
    }
}