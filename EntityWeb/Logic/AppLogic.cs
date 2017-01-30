using EntityWeb.DBInteraction;
using DataTypes;
using SignalR.AgentTicker;

namespace EntityWeb.Logic
{
    public class AppLogic
    {
        private AppDBInteraction AppDB = new AppDBInteraction();
        public AppLogic()
        {

        }
        public void AddNewDevice(AppDevice device)
        {
            AppDB.AddNewDevice(device);
        }
        public void Delete(AppDevice device)
        {
            AppDB.Delete(device);
        }
    }
}