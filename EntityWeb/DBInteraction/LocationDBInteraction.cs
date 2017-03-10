using EntityWeb.DAL;
using DataTypes;
using System.Linq;

namespace EntityWeb.DBInteraction
{
    public class LocationDBInteraction
    {
        private DataContext DB;

        public LocationDBInteraction()
        {
            DB = new DataContext();
        }

        public LocationCollection GetPrintLocations()
        {
            LocationCollection Locations = new LocationCollection();
            foreach (Location location in DB.PrintLocations)
            {
                Locations.AddLocation(location);
            }
            return Locations;
        }
    }
}