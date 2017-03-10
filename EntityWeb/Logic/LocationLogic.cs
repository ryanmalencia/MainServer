using EntityWeb.DBInteraction;
using DataTypes;
using SignalR.AgentTicker;

namespace EntityWeb.Logic
{
    public class LocationLogic
    {
        private LocationDBInteraction LocationDB = new LocationDBInteraction();

        public LocationCollection GetPrintLocations()
        {
            return LocationDB.GetPrintLocations();
        }
    }
}