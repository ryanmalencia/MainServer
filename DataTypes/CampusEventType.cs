namespace DataTypes
{
    public class CampusEventType
    {
        public int CampusEventTypeID { get; set; }
        public string Type { get; set; }
        public CampusEventType()
        {

        }
        public CampusEventType(string type)
        {
            Type = type;
        }
    }
}
