using System;

namespace DataTypes
{
    public class SportEvent : IComparable<SportEvent>
    {
        public int SportEventID { get; set; }
        public int SportID { get; set; }
        public string Opponent { get; set; }
        public string Result { get; set; }
        public string Location { get; set; }
        public string Broadcast { get; set; }
        public DateTime Date { get; set; }
        public string ImageLoc { get; set; }
        public bool Home { get; set; }
        public virtual Sport Sport { get; set; }

        public SportEvent()
        {

        }

        public SportEvent(DateTime date, Sport sport = null, string opponent = "", string result = "", string location = "", string broadcast = "", string imageloc = "",bool home = true)
        {
            if (sport == null)
            {
                Sport = new Sport();
            }
            else
            {
                Sport = sport;
            }
            Opponent = opponent;
            Result = result;
            Location = location;
            Broadcast = broadcast;
            Date = date;
            ImageLoc = imageloc;
            Home = home;
        }

        public int CompareTo(SportEvent other)
        {
            if (other != null)
            {
                if (Date != null && other.Date != null)
                {
                    return Date.CompareTo(other.Date);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}    