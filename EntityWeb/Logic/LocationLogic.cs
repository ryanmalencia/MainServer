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

        public PrintCollection GetDiningLocations()
        {
            return LocationDB.GetDiningLocations();
        }

        public void AddPrintLocation(PrintLocation location)
        {
            LocationDB.AddPrintLocation(location);
        }

        public void AddDiningLocations(DiningLocation location)
        {
            LocationDB.AddDiningLocations(location);
        }
        
        public DiningLocationCollection GetDiningCoords()
        {
            return LocationDB.GetDiningCoords();
        }
    }
}