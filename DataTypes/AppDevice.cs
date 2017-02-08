﻿using System;
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
        public string GoogID { get; set; }

        public AppDevice()
        {

        }

        public AppDevice(string RegID, string GoogID = "")
        {
            this.RegID = RegID;
            this.GoogID = GoogID;
        }
    }
}
