using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace EntityWeb.SignalR
{
    [HubName("LogTickerHub")]
    public class LogTickerHub : Hub
    {
        private readonly LogTicker _logTicker;

        public LogTickerHub() : this(LogTicker.Instance) { }

        public LogTickerHub(LogTicker logTicker)
        {
            _logTicker = logTicker;
        }
    }
}