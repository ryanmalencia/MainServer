using EntityWeb.DAL;
using DataTypes;
using System.Linq;

namespace EntityWeb.DBInteraction
{
    public class ConcertDBInteraction
    {
        private DataContext DB;
        public ConcertDBInteraction()
        {
            DB = new DataContext();
        }

        public void Add(Concert concert)
        {
            var Concert = DB.Concerts.FirstOrDefault(a => a.Band == concert.Band && a.Date == concert.Date && a.Venue == concert.Venue);
            if (Concert == null)
            {
                DB.Concerts.Add(concert);
                DB.SaveChanges();
            }
        }
    }
}