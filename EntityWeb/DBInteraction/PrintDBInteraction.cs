﻿using EntityWeb.DAL;
using DataTypes;
using System.IO;
using System.Linq;

namespace EntityWeb.DBInteraction
{
    public class PrintDBInteraction
    {
        public PrintCollection GetAllPrintLocations()
        {
            PrintCollection locations = new PrintCollection();
            locations.Locations = File.ReadAllLines(@"C:\AppFiles\printloc.txt").ToList();
            return locations;
        }
    }
}