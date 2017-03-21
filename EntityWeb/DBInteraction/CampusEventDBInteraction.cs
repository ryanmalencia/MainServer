﻿using EntityWeb.DAL;
using DataTypes;
using System.Linq;
using System;
using System.Collections.Generic;

namespace EntityWeb.DBInteraction
{
    public class CampusEventDBInteraction
    {
        private DataContext DB;

        public CampusEventDBInteraction()
        {
            DB = new DataContext();
        }

        public CampusEventCollection GetEventsByType(string type)
        {
            CampusEventCollection Events = new CampusEventCollection();

            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            Events.Events = DB.CampusEvents.Where(b => b.Date >= Date && b.Type.Type.ToLower() == type.ToLower()).OrderBy(a => a.Date).ToList();

            return Events;
        }

        public void AddEvent(CampusEvent Event)
        {
            var temp = DB.CampusEvents.FirstOrDefault(a => a.Date == Event.Date && a.Location == Event.Location && a.Title == Event.Title && a.Time == Event.Time);


            if(temp == null)
            {
                var temp2 = DB.CampusEventTypes.FirstOrDefault(a => a.Type == Event.Type.Type);
                if(temp2 != null)
                {
                    Event.Type = temp2;
                }
                if (Event.Type.Type.ToLower() != "practice")
                {
                    DB.CampusEvents.Add(Event);
                    DB.SaveChanges();
                }
            }
        }

        public CampusEventCollection GetFutureEvents(string type, int index = 0)
        {
            CampusEventCollection Events = new CampusEventCollection();

            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            List<CampusEvent> theevents = DB.CampusEvents.Where(b => b.Date >= Date && b.Type.Type.ToLower() == type.ToLower()).OrderBy(a => a.Date).ToList();

            int count = 15 * index;

            for (int i = count; i < count + 15; i++)
            {
                if (i >= theevents.Count)
                {
                    break;
                }
                Events.AddEvent(theevents[i]);
            }

            return Events;
        }            
    }
}