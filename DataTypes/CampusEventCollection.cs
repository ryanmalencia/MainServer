using System.Collections.Generic;

namespace DataTypes
{
    public class CampusEventCollection
    {
        public List<CampusEvent> Events;

        public CampusEventCollection()
        {
            Events = new List<CampusEvent>();
        }

        public void AddEvent(CampusEvent Event)
        {
            Events.Add(Event);
        }
    }
}
