﻿using EntityWeb.DAL;
using DataTypes;
using System;
using System.Collections.Generic;
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

        public ConcertCollection GetFutureConcerts(int page = 0)
        {
            ConcertCollection Concerts = new ConcertCollection();
            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            List<Concert> concerts = DB.Concerts.Where(b => b.Date >= Date).OrderBy(a => a.Date).ToList();
            int count = 15 * page;
            for (int i = count; i < count + 15; i++)
            {
                if (i >= concerts.Count)
                {
                    break;
                }
                Concerts.AddConcert(concerts[i]);
            }
            return Concerts;
        }
    }
}