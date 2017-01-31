using EntityWeb.DAL;
using DataTypes;
using System.Linq;

namespace EntityWeb.DBInteraction
{
    public class SportEventDBInteraction
    {
        private DataContext DB;

        public SportEventDBInteraction()
        {
            DB = new DataContext();
        }

        public void Add(SportEvent Event)
        {
            var oldevent = DB.SportEvents.FirstOrDefault(a => a.Location == Event.Location && a.Sport.Name == Event.Sport.Name && a.Opponent == Event.Opponent && a.Date == Event.Date);
            if(oldevent == null)
            {
                var sport = DB.Sports.FirstOrDefault(a => a.Name == Event.Sport.Name);
                if(sport != null)
                {
                    Event.Sport = sport;
                }
                DB.SportEvents.Add(Event);
            }
            DB.SaveChanges();
        }
    }
}