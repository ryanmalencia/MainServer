﻿using EntityWeb.DAL;
using DataTypes;
using System.Linq;
using System;

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
    }
}