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

            if (loc == null)
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

        public void AddFitnessLocations(FitnessLocation location)
        {
            var loc = DB.FitnessLocations.FirstOrDefault(a => a.Latitude == location.Latitude && a.Longitude == location.Longitude);

            if (loc == null)
            {
                DB.FitnessLocations.Add(location);
                DB.SaveChanges();
            }
        }

        public LocationCollection GetFitnessCoords()
        {
            LocationCollection Locations = new LocationCollection();
            foreach (FitnessLocation location in DB.FitnessLocations)
            {
                Locations.AddLocation(location);
            }
            return Locations;
        }

        public PrintCollection GetFitnessLocations()
        {
            PrintCollection Locations = new PrintCollection();
            Locations.Locations = File.ReadAllLines(@"C:\AppFiles\fitnessdata.txt").ToList();
            return Locations;
        }

        public void AddLibraryLocations(LibraryLocation location)
        {
            var loc = DB.LibraryLocations.FirstOrDefault(a => a.Latitude == location.Latitude && a.Longitude == location.Longitude);

            if (loc == null)
            {
                DB.LibraryLocations.Add(location);
                DB.SaveChanges();
            }
        }

        public LocationCollection GetLibraryCoords()
        {
            LocationCollection Locations = new LocationCollection();
            foreach (LibraryLocation location in DB.LibraryLocations)
            {
                Locations.AddLocation(location);
            }
            return Locations;
        }

        public PrintCollection GetLibraryLocations()
        {
            PrintCollection Locations = new PrintCollection();
            Locations.Locations = File.ReadAllLines(@"C:\AppFiles\librarydata.txt").ToList();
            return Locations;
        }

        public void AddComputerLocations(ComputerLocation location)
        {
            var loc = DB.ComputerLocations.FirstOrDefault(a => a.Latitude == location.Latitude && a.Longitude == location.Longitude);

            if (loc == null)
            {
                DB.ComputerLocations.Add(location);
                DB.SaveChanges();
            }
        }

        public LocationCollection GetComputerCoords()
        {
            LocationCollection Locations = new LocationCollection();
            foreach (ComputerLocation location in DB.ComputerLocations)
            {
                Locations.AddLocation(location);
            }
            return Locations;
        }

        public PrintCollection GetComputerLocations()
        {
            PrintCollection Locations = new PrintCollection();
            Locations.Locations = File.ReadAllLines(@"C:\AppFiles\computerdata.txt").ToList();
            return Locations;
        }
    }
}