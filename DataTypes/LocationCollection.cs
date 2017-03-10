using System.Collections.Generic;

namespace DataTypes
{
    public class LocationCollection
    {
        public List<Location> Locations;

        public LocationCollection()
        {
            Locations = new List<Location>();
        }

        public void AddLocation(Location location)
        {
            Locations.Add(location);
        }
    }
}
