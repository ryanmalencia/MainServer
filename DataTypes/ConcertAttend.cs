namespace DataTypes
{
    public class ConcertAttend
    {
        public int ConcertAttendID { get; set; }
        public int ConcertID { get; set; }
        public int UserID { get; set; }
        public bool Going { get; set; }

        public ConcertAttend(int ConcertID = 0, int UserID = 0, bool Going = true)
        {
            this.ConcertID = ConcertID;
            this.UserID = UserID;
            this.Going = Going;
        }
        public ConcertAttend()
        {

        }
    }
}
