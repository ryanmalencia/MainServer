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
    }
}