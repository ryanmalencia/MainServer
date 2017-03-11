using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class LocationLogic
    {
        private LocationDBInteraction LocationDB = new LocationDBInteraction();

        public LocationCollection GetPrintLocations()
        {
            return LocationDB.GetPrintLocations();
        }

        public void AddPrintLocation(PrintLocation location)
        {
            LocationDB.AddPrintLocation(location);
        }
    }
}