using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class AppDevice
    {
        public int AppDeviceID { get; set; }
        public string RegID { get; set; }
        public int UserID { get; set; }

        public AppDevice()
        {

        }
        public AppDevice(string RegID, int UserID = 0)
        {
            this.RegID = RegID;
            this.UserID = UserID;
        }
    }
}
