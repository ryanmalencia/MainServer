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
            foreach (PrintLocation location in DB.PrintLocations)
            {
                Locations.AddLocation(location);
            }
            return Locations;
        }

        public void AddPrintLocation(PrintLocation location)
        {
            var loc = DB.PrintLocations.FirstOrDefault(a => a.Latitude == location.Latitude && a.Longitude == location.Longitude && a.Name == location.Name);

            if(loc == null)
            {
                DB.PrintLocations.Add(location);
                DB.SaveChanges();
            }
        }
    }
}