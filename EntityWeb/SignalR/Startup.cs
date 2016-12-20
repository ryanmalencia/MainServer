using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR.InformationTicker.Startup))]

namespace SignalR.InformationTicker
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
