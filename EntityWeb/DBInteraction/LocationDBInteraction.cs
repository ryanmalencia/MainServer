using EntityWeb.DAL;
using DataTypes;
using System.Linq;
using System.IO;

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

        public PrintCollection GetDiningLocations()
        {
            PrintCollection Locations = new PrintCollection();
            Locations.Locations = File.ReadAllLines(@"C:\AppFiles\fooddata.txt").ToList();
            return Locations;
        }

        public DiningLocationCollection GetDiningCoords()
        {
            DiningLocationCollection Locations = new DiningLocationCollection();
            Locations.Locations = DB.DiningLocations.ToList();
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

        public void AddDiningLocations(DiningLocation location)
        {
            var loc = DB.DiningLocations.FirstOrDefault(a => a.Latitude == location.Latitude && a.Longitude == location.Longitude);

            if (loc == null)
            {
                DB.DiningLocations.Add(location);
                DB.SaveChanges();
            }
        }
    }
}