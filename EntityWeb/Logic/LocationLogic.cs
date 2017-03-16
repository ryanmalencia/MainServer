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

        public void AddFitnessLocations(FitnessLocation location)
        {
            LocationDB.AddFitnessLocations(location);
        }

        public LocationCollection GetFitnessCoords()
        {
            return LocationDB.GetFitnessCoords();
        }

        public PrintCollection GetFitnessLocations()
        {
            return LocationDB.GetFitnessLocations();
        }

        public void AddLibraryLocations(LibraryLocation location)
        {
            LocationDB.AddLibraryLocations(location);
        }

        public LocationCollection GetLibraryCoords()
        {
            return LocationDB.GetLibraryCoords();
        }

        public PrintCollection GetLibraryLocations()
        {
            return LocationDB.GetLibraryLocations();
        }

        public void AddComputerLocations(ComputerLocation location)
        {
            LocationDB.AddComputerLocations(location);
        }

        public LocationCollection GetComputerCoords()
        {
            return LocationDB.GetComputerCoords();
        }

        public PrintCollection GetComputerLocations()
        {
            return LocationDB.GetComputerLocations();
        }
    }
}