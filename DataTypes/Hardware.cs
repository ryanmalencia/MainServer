namespace DataTypes
{
    public class Hardware
    {
        public string Name { get; set; }
        public string Disk { get; set; }
        public string CPU { get; set; }
        public string Ram { get; set; }

        public Hardware()
        {

        }

        public Hardware(string N, string D, string C, string R)
        {
            Name = N;
            Disk = D;
            CPU = C;
            Ram = R;
        }
    }
}
