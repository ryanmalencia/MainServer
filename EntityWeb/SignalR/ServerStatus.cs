using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DataTypes;
using EntityWeb.DBInteraction;

namespace EntityWeb.SignalR
{
    public class ServerStatus
    {
        private readonly static Lazy<ServerStatus> _instance = new Lazy<ServerStatus>(() => new ServerStatus(GlobalHost.ConnectionManager.GetHubContext<ServerStatusHub>().Clients));


        private ServerStatus(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        public static ServerStatus Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void UpdateDesktop(bool status)
        {
            Clients.All.updateDesktop(status);
        }

        public void UpdateSQL(bool status)
        {
            Clients.All.updateSQL(status);
        }
    }
}