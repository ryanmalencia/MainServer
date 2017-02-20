using EntityWeb.DBInteraction;
using DataTypes;

namespace EntityWeb.Logic
{
    public class ConcertLogic
    {
        private ConcertDBInteraction ConcertDB = new ConcertDBInteraction();
        public void Add(Concert concert)
        {
            ConcertDB.Add(concert);
        }
        public ConcertCollection GetFutureConcerts(int index = 0)
        {
            return ConcertDB.GetFutureConcerts(index);
        }

        public ConcertCollection GetFutureUserConcerts(int UserID, int index = 0)
        {
            return ConcertDB.GetFutureUserConcerts(UserID,index);
        }

        public void AddOneGoing(int id, int user)
        {
            ConcertDB.AddOneGoing(id, user);
        }

        public void MinusOneGoing(int id, int user)
        {
            ConcertDB.MinusOneGoing(id, user);
        }

        public ConcertAttend GetAttendStatus(int id, int user)
        {
            return ConcertDB.GetAttendStatus(id, user);
        }
    }
}