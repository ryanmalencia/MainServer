using System;

namespace DataTypes
{
    public class Concert
    {
        public int ConcertID { get; set; }
        public string Band { get; set; }
        public string Venue { get; set; }
        public string ImageLink { get; set; }
        public string TicketLink { get; set; }
        public DateTime Date { get; set; }
        public int Going { get; set; }

        public Concert()
        {

        }

        public Concert(int ConcertID = 0,string Band = "", string Venue="", string ImageLink = "", string TicketLink = "", DateTime Date = new DateTime())
        {
            this.ConcertID = ConcertID;
            this.Band = Band;
            this.Venue = Venue;
            this.ImageLink = ImageLink;
            this.TicketLink = TicketLink;
            this.Date = Date;
        }
    }
}
