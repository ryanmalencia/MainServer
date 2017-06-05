using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DataTypes;

namespace EntityWeb.SignalR
{
    public class LogTicker
    {
        private readonly static Lazy<LogTicker> _instance = new Lazy<LogTicker>(() => new LogTicker(GlobalHost.ConnectionManager.GetHubContext<LogTickerHub>().Clients));

        private LogTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        public static LogTicker Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void NewLogMessage(Log log)
        {
            Clients.All.newLogMessage(log);
        }
    }
}