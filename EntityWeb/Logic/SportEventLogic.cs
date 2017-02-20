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
        public SportEventCollection GetFutureEvents(int index = 0)
        {
            return SportDB.GetFutureEvents(index);
        }

        public SportEventCollection GetFutureUserEvents(int UserID, int index = 0)
        {
            return SportDB.GetFutureUserEvents(UserID, index);
        }
        public void AddOneGoing(int id, int user)
        {
            SportDB.AddOneGoing(id, user);
        }

        public void MinusOneGoing(int id, int user)
        {
            SportDB.MinusOneGoing(id, user);
        }

        public SportEventAttend GetAttendStatus(int id, int user)
        {
            return SportDB.GetAttendStatus(id, user);
        }
    }
}