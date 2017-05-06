
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DataTypes;


namespace EntityWeb.SignalR
{
    [HubName("ServerStatusHub")]
    public class ServerStatusHub : Hub
    {
        private readonly ServerStatus _serverStatus;

        public ServerStatusHub() : this(ServerStatus.Instance) { }

        public ServerStatusHub(ServerStatus serverStatus)
        {
            _serverStatus = serverStatus;
        }
    }
}