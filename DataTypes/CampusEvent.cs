using System;

namespace DataTypes
{
    public class CampusEvent
    {
        public int CampusEventID { get; set; }
        public int CampusEventTypeID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public virtual CampusEventType Type { get; set; }
        public string Organization { get; set; }

        public CampusEvent()
        {

        }

        public CampusEvent(DateTime date, string title = "", string time= "", string location = "", string organization= "")
        {
            Date = date;
            Title = title;
            Location = location;
            Time = time;
            Organization = organization;
        }
    }
}
