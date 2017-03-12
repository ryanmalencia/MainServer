using System.Collections.Generic;

namespace DataTypes
{
    public class DiningLocationCollection
    {
        public List<DiningLocation> Locations;

        public DiningLocationCollection()
        {
            Locations = new List<DiningLocation>();
        }

        public void AddLocation(DiningLocation location)
        {
            Locations.Add(location);
        }
    }
}
