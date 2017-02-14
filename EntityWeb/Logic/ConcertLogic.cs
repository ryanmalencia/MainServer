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
    }
}