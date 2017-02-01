using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class SportEventLogic
    {
        private SportEventDBInteraction SportDB = new SportEventDBInteraction();
        public SportEventLogic()
        {

        }
        public void Add(SportEvent Event)
        {
            SportDB.Add(Event);
        }
        public SportEventCollection GetFutureEvents()
        {
            return SportDB.GetFutureEvents();
        }
    }
}