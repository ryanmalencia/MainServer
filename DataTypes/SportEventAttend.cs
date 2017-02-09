namespace DataTypes
{
    public class SportEventAttend
    {
        public int SportEventAttendID { get; set; }
        public int SportEventID { get; set; }
        public int UserID { get; set; }
        public bool Going { get; set; }

        public SportEventAttend(int SportEventID = 0, int UserID = 0,bool Going = true)
        {
            this.SportEventID = SportEventID;
            this.UserID = UserID;
            this.Going = Going;
        }
        public SportEventAttend()
        {

        }
    }
}
