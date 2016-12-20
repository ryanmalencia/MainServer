using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.InformationTicker
{
    public class InformationTicker
    {
        private readonly static Lazy<InformationTicker> _instance = new Lazy<InformationTicker>(() => new InformationTicker(GlobalHost.ConnectionManager.GetHubContext<InformationTickerHub>().Clients));
        private readonly ConcurrentDictionary<string, Information> _information = new ConcurrentDictionary<string, Information>();
        private readonly object _informationLock = new object();
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(1000);
        private readonly Timer _timer;
        private volatile bool _updatingInformation = false;

        private InformationTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            var information = new List<Information>
            {
                new Information {Id = 1, Name = "One" },
                new Information {Id = 2, Name = "Two" }
            };
            information.ForEach(info => _information.TryAdd(info.Name, info));

            _timer = new Timer(UpdateInformation, null, _updateInterval, _updateInterval);
        }

        public static InformationTicker Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public IEnumerable<Information> GetAllInformation()
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
                        if(TryUpdateInformation(info))
                        {
                            BroadcastInformation(info);
                        }
                    }
                    _updatingInformation = false;
                }
            }
        }

        private bool TryUpdateInformation(Information info)
        {
            if(info.Name.Length > 7)
            {
                info.Name = info.Name.Split('!')[0];
            }
            info.Name = info.Name + "!";
            return true;
        }

        private void BroadcastInformation(Information info)
        {
            Clients.All.updateInformation(info);
        }
    }
}