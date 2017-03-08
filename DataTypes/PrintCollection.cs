using System.Collections.Generic;

namespace DataTypes
{
    public class PrintCollection
    {
        public List<string> Locations;

        public PrintCollection()
        {
            Locations = new List<string>();
        }

        public PrintCollection(List<string> Locs)
        {
            Locations = Locs;
        }

        public void AddLocation(string location)
        {
            Locations.Add(location);
        }
    }
}
