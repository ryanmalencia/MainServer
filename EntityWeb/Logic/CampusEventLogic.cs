using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class CampusEventLogic
    {
        private CampusEventDBInteraction EventDB = new CampusEventDBInteraction();

        public CampusEventCollection GetEventsByType(string type)
        {
            return EventDB.GetEventsByType(type);
        }

        public void AddEvent(CampusEvent Event)
        {
            EventDB.AddEvent(Event);
        }

        public CampusEventCollection GetFutureEvents(string type, int index = 0)
        {
            return EventDB.GetFutureEvents(type, index);
        }
        public CampusEventCollection GetAllEvents()
        {
            return EventDB.GetAllEvents();
        }

        public void UpdateEventDate(CampusEvent Event)
        {
            EventDB.UpdateEventDate(Event);
        }

        public CampusEventCollection GetNextHourEvents(string type)
        {
            return EventDB.GetNextHourEvents(type);
        }
    }
}