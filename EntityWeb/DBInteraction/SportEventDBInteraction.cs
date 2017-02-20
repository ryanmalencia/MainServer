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

            int count = 15 * page;

            for(int i = count; i < count + 15; i ++)
            {
                if(i >= theevents.Count)
                {
                    break;
                }
                Events.AddEvent(theevents[i]);
            }

            return Events;
        }
        public SportEventCollection GetFutureUserEvents(int UserID,int page = 0)
        {
            SportEventCollection Events = new SportEventCollection();

            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            List<SportEvent> theevents = DB.SportEvents.Where(b => b.Date >= Date).OrderBy(a => a.Date).ToList();

            int count = 15 * page;

            for (int i = count; i < count + 15; i++)
            {
                if (i >= theevents.Count)
                {
                    break;
                }
                int ID = theevents[i].SportEventID;
                var going = DB.SportEventAttendees.FirstOrDefault(a => a.SportEventID == ID && a.UserID == UserID);
                if(going != null)
                {
                    if(going.Going)
                    {
                        theevents[i].UserGoing = going.Going;
                    }
                }
                if (theevents[i].Home || theevents[i].Broadcast.Trim().Length > 0)
                {
                    Events.AddEvent(theevents[i]);
                }
                else
                {
                    count++;
                }
            }

            return Events;
        }


        public void AddOneGoing(int id, int user)
        {
            var Event = DB.SportEvents.FirstOrDefault(a => a.SportEventID == id);
            var Attend = DB.SportEventAttendees.FirstOrDefault(a => a.SportEventID == id && a.UserID == user);
            if(Event != null)
            {
                Event.Going++;
                DB.SaveChanges();
            }

            if(Attend == null)
            {
                DB.SportEventAttendees.Add(new SportEventAttend(id, user,true));
                DB.SaveChanges();
            }
            else
            {
                Attend.Going = true;
                DB.SaveChanges();
            }
        }

        public void MinusOneGoing(int id, int user)
        {
            var Event = DB.SportEvents.FirstOrDefault(a => a.SportEventID == id);
            var Attend = DB.SportEventAttendees.FirstOrDefault(a => a.SportEventID == id && a.UserID == user);
            if (Event != null)
            {
                if (Event.Going > 0)
                {
                    Event.Going--;
                    DB.SaveChanges();
                }
            }
            if (Attend != null)
            {
                Attend.Going = false;
                DB.SaveChanges();
            }
        }

        public SportEventAttend GetAttendStatus(int id, int user)
        {
            var Attend = DB.SportEventAttendees.FirstOrDefault(a => a.SportEventID == id && a.UserID == user);

            if(Attend != null)
            {
                return Attend;
            }
            else
            {
                return new SportEventAttend(Going:false);
            }
        }
    }
}