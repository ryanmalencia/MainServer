using EntityWeb.DAL;
using DataTypes;
using System.Collections.Generic;
using System.Linq;
using System;

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
            var oldevent = DB.SportEvents.FirstOrDefault(a => a.Location == Event.Location && a.Sport.Name == Event.Sport.Name && (a.Opponent.Contains(Event.Opponent) || Event.Opponent.Contains(a.Opponent)) && a.Date == Event.Date);
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

        public SportEventCollection GetFutureEvents(int page = 0)
        {
            SportEventCollection Events = new SportEventCollection();

            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            List<SportEvent> theevents = DB.SportEvents.Where(b=> b.Date >= Date).OrderBy(a => a.Date).ToList();

            int count = 20 * page;

            for(int i = count; i < count + 20; i ++)
            {
                if(i >= theevents.Count)
                {
                    break;
                }
                Events.AddEvent(theevents[i]);
            }

            return Events;
        }

        public void AddOneGoing(int id)
        {
            var Event = DB.SportEvents.FirstOrDefault(a => a.SportEventID == id);

            if(Event != null)
            {
                Event.Going++;
            }

            DB.SaveChanges();
        }

        public void MinusOneGoing(int id)
        {
            var Event = DB.SportEvents.FirstOrDefault(a => a.SportEventID == id);

            if (Event != null)
            {
                Event.Going--;
            }

            DB.SaveChanges();
        }
    }
}