using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class ConcertCollection
    {
        public List<Concert> Concerts;
        public ConcertCollection()
        {
            Concerts = new List<Concert>();
        }

        public void AddConcert(Concert concert)
        {
            Concerts.Add(concert);
        }
    }
}
