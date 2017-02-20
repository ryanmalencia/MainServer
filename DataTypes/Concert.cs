using System;

namespace DataTypes
{
    public class Concert : IComparable<Concert>
    {
        public int ConcertID { get; set; }
        public string Band { get; set; }
        public string Venue { get; set; }
        public string ImageLink { get; set; }
        public string TicketLink { get; set; }
        public bool UserGoing { get; set; }
        public DateTime Date { get; set; }
        public int Going { get; set; }

        public Concert()
        {

        }

        public Concert(int ConcertID = 0,string Band = "", string Venue="", string ImageLink = "", string TicketLink = "", DateTime Date = new DateTime(), bool UserGoing = false)
        {
            this.ConcertID = ConcertID;
            this.Band = Band;
            this.Venue = Venue;
            this.ImageLink = ImageLink;
            this.TicketLink = TicketLink;
            this.Date = Date;
            this.UserGoing = UserGoing;
        }

        public int CompareTo(Concert other)
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
