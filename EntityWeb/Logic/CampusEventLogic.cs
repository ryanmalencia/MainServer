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
    }
}